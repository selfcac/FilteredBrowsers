using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharp.WinForms.Example.FilteringChrome
{
    public class XPathHelpers
    {
        public class XpathItem
        {
            public string domainPattern;
            public string epPattern;
            public int parentCount;
            public string xpath;

            public string toLine()
            {
                return string.Format("{0} {1} {2} {3}",
                    parentCount,
                    domainPattern,
                    epPattern,
                    xpath
                    );
            }

            static string getSubstring(string fullText, char stopChar, int startIndex, out int nextIndex)
            {
                string result = "";
                nextIndex = -1;

                int stopIndex = fullText.IndexOf(stopChar, startIndex);
                if (stopIndex > -1)
                {
                    result = fullText.Substring(startIndex, stopIndex - startIndex);
                    nextIndex = stopIndex + 1;
                }

                return result;
            }

            public static XpathItem fromLine(string line)
            {
                XpathItem result = new XpathItem();
                int[] indexes = { -1, -1, -1 };

                try
                {
                    line = line.Trim(new[] { '\r', '\n', ' ' });
                    result.parentCount = int.Parse(getSubstring(line, ' ', 0, out indexes[0]));
                    result.domainPattern = getSubstring(line, ' ', indexes[0], out indexes[1]);
                    result.epPattern = getSubstring(line, ' ', indexes[1], out indexes[2]);
                    result.xpath = line.Substring(indexes[2]);

                    int errorNum = indexes.Min();
                    if (errorNum < 0)
                        result = null;
                }
                catch (Exception ex)
                {
                    result = null;
                }

                return result;
            }
        }

        Dictionary<string, Dictionary<string, List<XpathItem>>> DomainEndpointItems =
            new Dictionary<string, Dictionary<string, List<XpathItem>>>();

        public void loadAllRules(string filepath)
        {
            foreach(string line in File.ReadLines(filepath))
            {
                XpathItem item = XpathItem.fromLine(line);
                AddItem(item);
            }
        }

        public void AddItem(XpathItem item)
        {
            if (item != null)
            {
                if (!DomainEndpointItems.ContainsKey(item.domainPattern))
                    DomainEndpointItems.Add(item.domainPattern, new Dictionary<string, List<XpathItem>>());

                if (!DomainEndpointItems[item.domainPattern].ContainsKey(item.epPattern))
                    DomainEndpointItems[item.domainPattern].Add(item.epPattern, new List<XpathItem>());

                DomainEndpointItems[item.domainPattern][item.epPattern].Add(item);
            }
        }

        public void filterAll(string url, Action<string, int> xpathCallback)
        {
            string url_domain = "*";
            string url_ep = "*";

            try
            {
                Uri u = new Uri(url);
                url_domain = u.Host;
                url_ep = u.PathAndQuery;
            }
            catch (Exception)
            {
            }

            foreach(string domain in DomainEndpointItems.Keys)
            {
                if (domain == "*" || url_domain.Contains(domain))
                {
                    foreach (string ep in DomainEndpointItems[domain].Keys)
                    {
                        if (ep == "*" || url_ep.Contains(ep))
                        {
                            foreach(var xpathItem in DomainEndpointItems[domain][ep])
                            {
                                try
                                {
                                    xpathCallback(xpathItem.xpath, xpathItem.parentCount);
                                }
                                catch (Exception ex)
                                {

                                        
                                }
                            }
                        }
                    }
                }
            }
           
        }
    }
}
