// Copyright © 2019 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using CefSharp.Example.Filters;
using CefSharp.Handler;

namespace CefSharp.Example.Handlers
{
    public class AddSecretHandler : ResourceRequestHandler
    {
        private string mySecret = "";
        const string prefixSecret = "--secret=";
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

        public AddSecretHandler()
        {
            foreach (string arg in Environment.GetCommandLineArgs())
            {
                if (arg.StartsWith(prefixSecret))
                {
                    mySecret = arg.Substring(prefixSecret.Length);
                }
            }
        }
        
        protected override CefReturnValue OnBeforeResourceLoad(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
        {
            string secret_hash = GetHashString(request.Url.ToLower() + mySecret).ToLower();
            request.SetHeaderByName(headerSecret, secret_hash, true);
            Debug.WriteLine(request.Url.ToLower() + ": " + secret_hash);
            
            return CefReturnValue.Continue;
        }

    }
}
