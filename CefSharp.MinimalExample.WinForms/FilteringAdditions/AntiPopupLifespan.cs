using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharp.MinimalExample.WinForms.FilteringAdditions
{
    class AntiPopupLifespan : ILifeSpanHandler
    {
        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            var defaultValue = false;
            return defaultValue;

        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {
            return;
        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {
            return;
        }

        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            bool block = true;
            return block;
        }
    }
}
