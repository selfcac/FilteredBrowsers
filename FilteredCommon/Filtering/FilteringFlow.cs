using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FilteredCommon.Filtering
{
    public class FilteringFlow
    {
        public const string blockedDevUrl = "about:blank";
        public const string evalHead = "document.getElementsByTagName(\"head\")[0].innerText";
        public const string evalBody = "document.getElementsByTagName(\"body\")[0].innerText";


        public static string evalReplaceHTML(string newbody)
        {
            return "document.getElementsByTagName(\"html\")[0].innerHTML=\"" + HttpUtility.JavaScriptStringEncode(newbody) + "\"";
        }

        public static string formatBlockpage(string reason)
        {
            string blockedHTML = FilteredCommon.Resources.SharedResources.getBlockedPage();
            return blockedHTML.Replace("{0}",
                ("<br/>" + reason)
                .Replace("<*", "<b>").Replace("*>", "</b>")
                .Replace("_<", "<u>").Replace(">_", "</u>"));
        }

        public static bool isTimeBlocked(TimeBlockFilter.TimeFilterObject timePolicy, DateTime target, ref string reason)
        {
            bool isBlocked =  timePolicy.isBlocked(target);
            if (isBlocked)
                reason = "Time <*" + target.ToShortTimeString() + "*> is blocked by time policy.";
            return isBlocked;
        }


        public static bool isNavigationBlocked(HTTPProtocolFilter.FilterPolicy httpPolicy,Uri referURI, Uri newURI, out string reason)
        {
            reason = "init final";
            bool isBlocked = true;

            if (httpPolicy.getMode() == HTTPProtocolFilter.WorkingMode.ENFORCE)
            {
                string urlReason = "init main reason";
                if (httpPolicy.isWhitelistedURL(newURI, out urlReason))
                {
                    isBlocked = false;
                }
                else // check the referer
                {
                    if (referURI != null)
                    {
                        string refererReason = "init ref reason";
                        if (httpPolicy.isWhitelistedURL(referURI, out refererReason))
                        {
                            if (httpPolicy.findAllowedDomain(referURI.Host).AllowRefering)
                            {
                                isBlocked = false;
                            }
                            else
                            {
                                reason = referURI.ToString() + " Is not allowed as referer. <br/><br/>" + urlReason;
                            }
                        }
                        else
                        {
                            reason = "<h3>Target:</h3></br>"
                                + urlReason + "<br /><h3>Referrer:</h3></br>" + refererReason;
                        }
                    }
                    else
                    {
                        reason = urlReason;
                    }
                }
            }
            else
            {
                isBlocked = false;
            }

            return isBlocked;
        }


        public static bool isHTMLPageBlocked(HTTPProtocolFilter.FilterPolicy httpPolicy, string HeaderText, string BodyText, out string reason)
        {
            bool isBlocked = false;
            reason = "init body reason";
            if (httpPolicy.isBodyBlocked(HeaderText, out reason))
            {
                reason = "Body is blocked. </br>" + reason;
                isBlocked = true;
            }
            else if (httpPolicy.isBodyBlocked(BodyText, out reason))
            {
                reason = "Header is blocked. </br>" + reason;
                isBlocked = true;
            }
            return isBlocked;
        }
    }
}
