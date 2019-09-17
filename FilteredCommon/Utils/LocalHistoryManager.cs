using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilteredCommon.DataStructure;

namespace FilteredEdgeBrowser
{
    public class HistoryItem
    {
        public Uri URL;
        public string Title;

        public override bool Equals(object obj)
        {
            HistoryItem other = obj as HistoryItem;
            if (other == null)
                return false;


            return URL.Equals(other.URL);
        }
    }

    public class LocalHistoryManager
    {
        CyclicFastDrop<HistoryItem> myCyclicHistory 
                    = new CyclicFastDrop<HistoryItem>(25);

        public void Navigated(Utils.LogFileHandler myHistoryHandler,  Uri url, string title)
        {
            HistoryItem newItem = new HistoryItem() { URL = url, Title = title };
            myCyclicHistory.AddAndDropFuture(newItem);
            myHistoryHandler.SaveUrlToFile(title, url.ToString());
        }

        public void NavigatedIndex(int i)
        {
            myCyclicHistory.CurrentPosition = i;
        }

        public int Size()
        {
            return myCyclicHistory.Size();
        }

        public Uri GoBack()
        {
            if (Size() > 0 && myCyclicHistory.CurrentPosition > 0)
            {
                myCyclicHistory.CurrentPosition--;
                return myCyclicHistory[myCyclicHistory.CurrentPosition].URL;
            }

            return null;
        }

        public Uri GoForward()
        {
            if (Size() > 0 && myCyclicHistory.CurrentPosition < (Size()-1))
            {
                myCyclicHistory.CurrentPosition++;
                return myCyclicHistory[myCyclicHistory.CurrentPosition].URL;
            }

            return null;
        }

        public int HistoryPosition()
        {
            return myCyclicHistory.CurrentPosition;
        }

        public HistoryItem this[int i]
        {
            get
            {
                return myCyclicHistory[i];
            }
        }


        public Uri CurrentURI()
        {
            if (Size() > 0)
            {
                return this[HistoryPosition()].URL;
            }
            else
            {
                return null;
            }
        }

        public string CurrentURL()
        {
            Uri uri = CurrentURI();
            return (uri == null) ? "" : uri.ToString();
        }
    }
}
