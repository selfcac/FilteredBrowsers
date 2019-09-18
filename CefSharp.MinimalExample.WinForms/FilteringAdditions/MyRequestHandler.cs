using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CefSharp.MinimalExample.WinForms.FilteringAdditions
{
    class MyRequestHandler : IRequestHandler
    {
        //http://cefsharp.github.io/api/57.0.0/html/T_CefSharp_IRequestHandler.htm

        public string lastReason = "";

        public bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool isRedirect)
        {
            bool isBlocked = false;

            if (frame.IsMain && request.Url.Length > 0 && request.Url != FilteringFlow.blockedDevUrl)
            {
                isBlocked = Common.shouldBlockNavigation(request.Url ?? "", request.ReferrerUrl ?? "", ref lastReason);
                if (isBlocked)
                {
                    browserControl.Load(FilteringFlow.blockedDevUrl);
                }
            }

            return isBlocked;
        }


        public static string BypassSecret = "";
        const string headerSecret = "mitm-secret";


        private static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        private static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();

        }

        public CefReturnValue OnBeforeResourceLoad(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
        {
            if (request.IsReadOnly)
            {
                throw new Exception("Read only!");
            }

            string secret_hash = GetHashString(request.Url.ToLower() + BypassSecret).ToLower();

            var tempHeaders = request.Headers;
            tempHeaders[headerSecret] = secret_hash;
            request.Headers = tempHeaders;

            return CefReturnValue.Continue;
        }

        // =======================================================================================================
        // =======================================================================================================
        // =======================================================================================================


        public bool GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
        {
            return false; // we wont provide any auth.
        }

        public IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            return null;
        }

        public bool OnCertificateError(IWebBrowser browserControl, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
        {
            return false;
        }

        public bool OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
        {
            return true; 
        }

        public void OnPluginCrashed(IWebBrowser browserControl, IBrowser browser, string pluginPath)
        {
            return;
        }

        public bool OnProtocolExecution(IWebBrowser browserControl, IBrowser browser, string url)
        {
            return false;
        }

        public bool OnQuotaRequest(IWebBrowser browserControl, IBrowser browser, string originUrl, long newSize, IRequestCallback callback)
        {
            return false;
        }

        public void OnRenderProcessTerminated(IWebBrowser browserControl, IBrowser browser, CefTerminationStatus status)
        {
            return;
        }

        public void OnRenderViewReady(IWebBrowser browserControl, IBrowser browser)
        {
            return;
        }

        public void OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
        {
            return;
        }

        public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
        {
            return;
        }

        public bool OnResourceResponse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            return false;
        }

        public bool OnSelectClientCertificate(IWebBrowser browserControl, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
        {
            return false;
        }
    }
}
