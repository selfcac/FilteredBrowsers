using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharp.MinimalExample.WinForms.FilteringAdditions
{
    public class TaskResult<T>
    {
        public bool Sucess;
        public T Result;
        public Exception error;

        public TaskResult(T defaultResult, bool defaultSucess = false, Exception defaultEx = null)
        {
            Sucess = defaultSucess;
            Result = defaultResult;
            error = defaultEx;
        }
    }

    public static class Common
    {

        public static async Task<TaskResult<string>> isFrameContentBlocked(IFrame frame, TimeSpan readTimeout)
        {
            TaskResult<string> result = new TaskResult<string>("");

            bool isBlocked = false;
            if (frame.IsValid && frame.Url != FilteringFlow.blockedDevUrl)
            {
                try
                {
                    var headerRes = await frame.EvaluateScriptAsync(
                       FilteringFlow.evalHead,
                       timeout: readTimeout
                   );

                    var bodyRes = await frame.EvaluateScriptAsync(
                        FilteringFlow.evalBody,
                        timeout: readTimeout
                    );

                    if (headerRes.Success && bodyRes.Success)
                    {
                        // No time block in content!! Let loaded data before curfew stay!
                        string finalResaon = "";
                        isBlocked = FilteringFlow.isHTMLPageBlocked(
                            BrowserForm.httpPolicy,
                            headerRes.Result as string,
                            bodyRes.Result as string,
                            out finalResaon
                            );
                        if (isBlocked)
                        {
                            finalResaon += " <br /> Source frame url: " + frame.Url;

                            result.Sucess = true;
                            result.Result = finalResaon;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Do nothing?
                }

            }

            return result;
        }

        public static async Task<TaskResult<string>> FilterAllFramesHTML(IWinFormsWebBrowser Browser, TimeSpan frameReadTimout)
        {
            TaskResult<string> result = new TaskResult<string>("");

            if (Browser.IsBrowserInitialized)
            {
                var mainFrame = Browser.GetMainFrame();
                List<long> allFrames = Browser.GetBrowser().GetFrameIdentifiers();
                for (int i = 0; i < allFrames.Count && !result.Sucess; i++)
                {
                    var currentFrame = Browser.GetBrowser().GetFrame(allFrames[i]);
                    if (currentFrame != null && currentFrame.IsValid && !currentFrame.IsDisposed)
                        result = await isFrameContentBlocked(currentFrame, frameReadTimout);
                }
            }

            return result;
        }

        public static Uri safeUrlConvertor(string url)
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

        public static bool shouldBlockNavigation(string Url, string ReferrerUrl, ref string reason)
        {
            bool isBlocked = false;
            string finalReason = "navigiated_init";
            bool blocked = FilteringFlow
                .isTimeBlocked(BrowserForm.timePolicy, DateTime.Now, ref finalReason);
            if (!blocked)
            {
                blocked = FilteringFlow
                    .isNavigationBlocked(BrowserForm.httpPolicy, safeUrlConvertor(ReferrerUrl), safeUrlConvertor(Url), out finalReason);
            }

            if (blocked)
            {
                reason = finalReason;
                isBlocked = true;
            }

            return isBlocked;
        }
    }
}
