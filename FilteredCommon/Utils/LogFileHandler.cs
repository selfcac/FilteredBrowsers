using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilteredEdgeBrowser.Utils
{
    class DataLock<T>
    {
        object myLock = new object();
        T data;

        public DataLock() { }
        public DataLock(T startValue) { data = startValue; }

        public void safeArea(Action<Func<T>, Action<T>> callback)
        {
            lock (myLock)
            {
                callback(() => { return data; }, (T newValue) => {
                    data = newValue;
                });
            }
        }
    }

    public class LogFileHandler
    {
        public const string DataSeperator = "|_&~%~&_|";

        private string oneLine(string input) { return input.Replace("\r", "").Replace("\n", ""); }

        private string myFilePath = "";
        public LogFileHandler(string filepath)
        {
            myFilePath = filepath;
        }

        public Action onSearchFinish;
        public Action<int> onProgressUpdated;

        Thread mainSearchThread = null;
        DataLock<bool> isThreadRunning = new DataLock<bool>(false);

        private bool stopSearchFlagUp = false;
        private string searchText = "";

        public void updateSearchParams(string newSearchText)
        {
            searchText = newSearchText;
            isThreadRunning.safeArea((alive, set) =>
            {
                if (!alive())
                {
                    //Spawn thread
                    mainSearchThread = new Thread(mainSearchLoop);
                    mainSearchThread.Start();
                }
            });
        }

        public void stopSearch()
        {
            isThreadRunning.safeArea((alive, set) =>
            {
                if (alive())
                {
                    stopSearchFlagUp = true;
                }
                // else the thread is stopped!
            });
        }

        private int _progress = 0;
        public int Progress()
        {
            return _progress;
        }

        public string[,] UrlResults = new string[100,2];
        public int resultCount = 0;

        private void mainSearchLoop()
        {
            isThreadRunning.safeArea((get, set) => { set(true); });

            string currentSearch = searchText;
            resultCount = 0;
            if (currentSearch == null || currentSearch.Length == 0)
            {
                stopSearchFlagUp = true;
            }

            bool isThreadStopping = stopSearchFlagUp;
            bool isSearchChanged = (currentSearch != searchText);

            while (!isThreadStopping)
            {
                using (ReverseLineReader file = new ReverseLineReader(myFilePath))
                {
                    foreach (string line in file)
                    {
                        if (!isThreadStopping && !isSearchChanged)
                        {

                            if (line.IndexOf(currentSearch, StringComparison.OrdinalIgnoreCase) > -1)
                            {
                                string[] data = line.Split(new[] { DataSeperator }, StringSplitOptions.RemoveEmptyEntries);
                                if (data.Length == 2)
                                {
                                    if (resultCount > UrlResults.Length -1)
                                    {
                                        stopSearchFlagUp = true;
                                        onSearchFinish?.Invoke();
                                    }
                                    else
                                    {
                                        UrlResults[resultCount,0] = data[0]; // name
                                        UrlResults[resultCount,1] = data[1]; // url
                                        resultCount++;
                                    }
                                   
                                }
                            }

                            int new_progress = (int)
                                (
                                (
                                1f -
                                file.myStream.Position * 1.0f / (file.myStream.Length + 1)
                                ) * 100.0f
                                );
                            if (Math.Abs(new_progress - _progress) > 1)
                            {
                                onProgressUpdated?.Invoke(new_progress);
                            }
                            _progress = new_progress;

                            isThreadStopping = stopSearchFlagUp;
                            isSearchChanged = (currentSearch != searchText);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (!isThreadStopping && isSearchChanged)
                {
                    currentSearch = searchText;
                    isSearchChanged = false;
                    resultCount = 0;
                    if (currentSearch == null || currentSearch.Length == 0)
                    {
                        stopSearchFlagUp = true;
                    }
                }
                else
                {
                    break; // no need to change search
                }
            }

            onSearchFinish?.Invoke();
            isThreadRunning.safeArea((get, set) => { set(false); });
            stopSearchFlagUp = false;
        }

        public bool isRunning()
        {
            bool result = false;
            isThreadRunning.safeArea((get, set) => { result =  get(); });
            return result;
        }

        public void SaveUrlToFile(string name, string url)
        {
            string toAppend = "[" + DateTime.Now.ToString() + "] " +  oneLine(name) + DataSeperator + oneLine(url);
            File.AppendAllLines(myFilePath, new[] { toAppend });
        }
    }
}
