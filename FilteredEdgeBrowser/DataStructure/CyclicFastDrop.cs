using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteredEdgeBrowser.DataStructure
{
    public class CyclicFastDrop<T> 
    {
        T[] _cyclicBuffer = null;

        public CyclicFastDrop(int arrayMaxSize)
        {
            _cyclicBuffer = new T[arrayMaxSize+1];
        }

        int _currentPosition = 0;
        int _firstElementPosition = 0;
        int _nextElementPosition = 0;

        // ================ Helpers ================

        int cyclicDistance(int startIndex, int lastIndex)
        {
            if (lastIndex >= startIndex)
            {
                // The array is like this XX[=====]XX
                return lastIndex - startIndex;
            }
            else
            {
                // The array is like this ==]XXXXX[==
                return (lastIndex - 0) + (_cyclicBuffer.Length - startIndex);
            }
        }

        int getCyclicDelta(int delta, int startIndex)
        {
            int requestedLocation = delta + startIndex;
            int bufferSize = _cyclicBuffer.Length;

            if (requestedLocation >= bufferSize)
            {
                return requestedLocation % bufferSize;
            }
            else if (requestedLocation < 0)
            {
                return (requestedLocation % bufferSize) + bufferSize;
            }
            else
            {
                return requestedLocation;
            }
        }
    
        int getRelativeToCurrent(int delta)
        {
            return getCyclicDelta(delta, _currentPosition);
        }

        // ================ Public ================

        public int Size()
        {
            return cyclicDistance(_firstElementPosition, _nextElementPosition);
        }

        public void AddAndDropFuture(T newItem)
        {
            int size = Size();
           
            if (size == 0) // _next == _current
            {
                _nextElementPosition = getRelativeToCurrent(+1);
                _cyclicBuffer[_currentPosition] = newItem;
            }
            else if (!newItem.Equals(_cyclicBuffer[getRelativeToCurrent(0)]))
            {
                // Add new element
                _nextElementPosition = getRelativeToCurrent(+2);
                _cyclicBuffer[getRelativeToCurrent(+1)] = newItem;
                _currentPosition = getRelativeToCurrent(+1);                

                if (_nextElementPosition == _firstElementPosition)
                {
                    // To avoid looking like empty array.
                    _firstElementPosition = getCyclicDelta(+1, _firstElementPosition);
                }
            }
        }

        public int CurrentPosition
        {
            get
            {
                return cyclicDistance(_firstElementPosition, _currentPosition);
            }
            set
            {
                if (value > -1 && value < Size())
                {
                    _currentPosition = _firstElementPosition;
                    _currentPosition = getRelativeToCurrent(value);
                }
            }
        }

        public T this[int i]
        {
            get {
                if (i >= 0 && i < Size())
                {
                    return _cyclicBuffer[getCyclicDelta(i, _firstElementPosition)];
                }
                else
                {
                    throw new Exception("Requested index " + i + " is out of bounds ("+ Size() +")");
                }
            }
        }

    }
}
