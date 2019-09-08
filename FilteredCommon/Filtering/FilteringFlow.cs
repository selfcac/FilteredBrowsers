using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteredCommon.Filtering
{
    public class FilteringFlow
    {
        public static string formatBlockpage(string reason)
        {
            string blockedHTML = FilteredCommon.Resources.SharedResources.getBlockedPage();
            return blockedHTML.Replace("{0}",
                ("<br/>" + reason)
                .Replace("<*", "<b>").Replace("*>", "</b>")
                .Replace("_<", "<u>").Replace(">_", "</u>"));
        }

        public static bool isNavigationBlocked(HTTPProtocolFilter.FilterPolicy policy,Uri referURI, Uri newURI, out string finalReason)
        {
            finalReason = "init final";
            bool isBlocked = false;

            if (policy.getMode() == HTTPProtocolFilter.WorkingMode.ENFORCE)
            {
                isBlocked = true;

                // TODO: Filter here
                string urlReason = "init main reason";
                if (policy.isWhitelistedURL(newURI, out urlReason))
                {
                    isBlocked = false;
                }
                else // check the referer
                {
                    if (referURI != null)
                    {
                        string refererReason = "init ref reason";
                        if (policy.isWhitelistedURL(referURI, out refererReason))
                        {
                            if (policy.findAllowedDomain(referURI.Host).AllowRefering)
                            {
                                isBlocked = false;
                            }
                            else
                            {
                                finalReason = referURI.ToString() + " Is not allowed as referer. <br/><br/>" + urlReason;
                            }
                        }
                        else
                        {
                            finalReason = "<h3>Target:</h3></br>"
                                + urlReason + "<br /><h3>Referrer:</h3></br>" + refererReason;
                        }
                    }
                    else
                    {
                        finalReason = urlReason;
                    }
                }
            }

            return isBlocked;
        }
    }
}
