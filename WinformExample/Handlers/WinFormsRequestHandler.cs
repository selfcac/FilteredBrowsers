// Copyright © 2015 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using CefSharp.Example.Handlers;
using CefSharp.WinForms.Internals;

using System.Security.Cryptography;
using System.Text;

namespace CefSharp.WinForms.Example.Handlers
{
    public class WinFormsRequestHandler : ExampleRequestHandler
    {
        private readonly Action<string, int?> openNewTab;


        public WinFormsRequestHandler(Action<string, int?> openNewTab)
        {
            this.openNewTab = openNewTab;
        }

        protected override bool OnOpenUrlFromTab(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
        {
            if (openNewTab == null)
            {
                return false;
            }

            var control = (Control)chromiumWebBrowser;

            control.InvokeOnUiThreadIfRequired(delegate ()
            {
                openNewTab(targetUrl, null);
            });

            return true;
        }

        protected override bool OnSelectClientCertificate(IWebBrowser chromiumWebBrowser, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
        {
            var control = (Control)chromiumWebBrowser;

            control.InvokeOnUiThreadIfRequired(delegate ()
            {
                var selectedCertificateCollection = X509Certificate2UI.SelectFromCollection(certificates, "Certificates Dialog", "Select Certificate for authentication", X509SelectionFlag.SingleSelection);
                if (selectedCertificateCollection.Count > 0)
                {
                    //X509Certificate2UI.SelectFromCollection returns a collection, we've used SingleSelection, so just take the first
                    //The underlying CEF implementation only accepts a single certificate
                    callback.Select(selectedCertificateCollection[0]);
                }
                else
                {
                    //User canceled no certificate should be selected.
                    callback.Select(null);
                }
            });

            return true;
        }

        public string lastReason = "";

        Uri safeUrlConvertor(string url)
        {
            Uri result = null;
            url = Uri.EscapeUriString(url);

            if (url.Length > 0 && Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                result = new Uri(url);
            }

            if (result == null)
            {
                result = new Uri("http://unkown.domain.please.ignore.com/");
            }


            return result;
        }

        protected override bool OnBeforeBrowse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect)
        {
            bool cancelRequest = base.OnBeforeBrowse(chromiumWebBrowser, browser, frame, request, userGesture, isRedirect);
            if (frame.IsMain && frame.Url.Length > 0 && frame.Url != FilteredCommon.Filtering.FilteringFlow.blockedDevUrl)
            {
                string finalReason = "navigiated_init";
                bool blocked = FilteredCommon.Filtering.FilteringFlow
                    .isTimeBlocked(BrowserForm.timePolicy, DateTime.Now, ref finalReason);
                if (!blocked)
                {
                    blocked = FilteredCommon.Filtering.FilteringFlow
                        .isNavigationBlocked(BrowserForm.httpPolicy, safeUrlConvertor(request.ReferrerUrl), safeUrlConvertor(request.Url), out finalReason);
                }

                if (blocked)
                {
                    cancelRequest = true;
                    chromiumWebBrowser.Load(FilteredCommon.Filtering.FilteringFlow.blockedDevUrl);
                }
            }
            return cancelRequest;
        }


        protected override IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
        {
            return base.GetResourceRequestHandler(chromiumWebBrowser, browser, frame, request, isNavigation, isDownload, requestInitiator, ref disableDefaultHandling);
        }

         






    }
}
