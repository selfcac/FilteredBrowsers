// Copyright © 2014 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefSharp.WinForms.Example.Handlers
{
    internal class MenuHandler : IContextMenuHandler
    {
        
        private const int ShowDevTools = 26501;
        private const int CloseDevTools = 26502;

        private const int ShowFind = 26503;
        private const int CopyUrl = 26504;


        Action showFind;

        public MenuHandler(Action ShowFind)
        {
            showFind = ShowFind;
        }

        void IContextMenuHandler.OnBeforeContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            //To disable the menu then call clear
            // model.Clear();

            //Removing existing menu item
            bool removed = model.Remove(CefMenuCommand.ViewSource); // Remove "View Source" option
            removed = model.Remove(CefMenuCommand.Print); 

            //Add new custom menu items
            //model.AddItem((CefMenuCommand)ShowDevTools, "Show DevTools");
            //model.AddItem((CefMenuCommand)CloseDevTools, "Close DevTools");
            model.AddItem((CefMenuCommand)ShowFind, "Find in page");
            model.AddItem((CefMenuCommand)CopyUrl, "Copy URL");
        }

        string scriptWithMousePos(int x, int y)
        {
            string result = "";
            string template = @"
(function() {
    var e = document.elementFromPoint({x}, {y});
    var b = e.style.backgroundColor;
    e.style.backgroundColor = 'yellow';
    setTimeout(function() { e.style.backgroundColor = b}, 2000);
    })()
";
            result = template.Replace("{x}", x.ToString()).Replace("{y}", y.ToString());
            return result;
        }

        bool IContextMenuHandler.OnContextMenuCommand(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            //if ((int)commandId == ShowDevTools)
            //{
            //    browser.ShowDevTools();
            //}
            //if ((int)commandId == CloseDevTools)
            //{
            //    browser.CloseDevTools();
            //}
            if ((int)commandId == ShowFind)
            {
                showFind();
            }
            else if ((int)commandId == CopyUrl)
            {
                System.Windows.Forms.Clipboard.SetText(browser.MainFrame.Url);
            }

            frame.EvaluateScriptAsync(scriptWithMousePos(parameters.XCoord, parameters.YCoord)).ContinueWith(async (resp) =>
            {
                var r = await resp;
                if (r.Success)
                {
                    //MessageBox.Show(r.Result.ToString());
                }
            });

            return false;
        }

        void IContextMenuHandler.OnContextMenuDismissed(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame)
        {

        }

        bool IContextMenuHandler.RunContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }
}
