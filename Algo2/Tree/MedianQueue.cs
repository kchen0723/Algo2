using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Tree
{
    public class MedianQueue
    {
        //sort from max to min, the very first item is max. Save the low half part of the queue
        private SortedList<int, int> _maxList = new SortedList<int, int> ();
        //sort from min to max, the very first item is min. Save the max half part of the queue
        private SortedList<int, int> _minList = new SortedList<int, int> (); 

        private int GetFirst(SortedList<int, int> list)
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }
            var result = 0;
            foreach ( var item in list)
            {
                result = item.Value;
                break;
            }
            return result;
        }

        //firt try to insert into the maxList.
        //maxList count always be equal to minList count, or minList count + 1.
        public void Enque(int number)
        {
            //first, insert into the maxList
            if (_maxList.Count == 0)
            { 
                _maxList.Add(0 - number, number);
                return;
            }

            var maxFirst = GetFirst(_maxList);
            if (_minList.Count == 0)
            {
                if (maxFirst < number)
                {
                    _minList.Add(number, number);
                }
                else
                {
                    _maxList.Remove(0 - maxFirst);
                    _minList.Add(maxFirst, maxFirst);
                    _maxList.Add(0 - number, number);
                }
                return;
            }

            var minFirst = GetFirst(_minList);
            if (number < minFirst) 
            {
                if (number < maxFirst) //should insert into the maxlist
                {
                    if (_maxList.Count == _minList.Count + 1) // maxlist have 1 more number than the min list, the move one to the minlist
                    {
                        _maxList.Remove(0 - maxFirst);
                        _minList.Add(maxFirst, maxFirst);
                    }
                    _maxList.Add(0 - number, number); //now add to the maxlist
                }
                else
                {
                    if (_maxList.Count == _minList.Count)
                    {
                        _maxList.Add(0 - number, number);
                    }
                    else
                    {
                        _minList.Add(number, number);
                    }
                }
            }
            else //should insert into the minlist
            {
                if (_maxList.Count == _minList.Count)
                {
                    _minList.Remove(minFirst);
                    _maxList.Add(0 - minFirst, minFirst);
                }
                _minList.Add(number, number);
            }
        }

        public float GetMedian()
        {
            if (_maxList.Count == 0)
            {
                throw new InvalidOperationException("no any elements");
            }

            var result = 0f;
            if (_minList.Count == _maxList.Count)
            {
                var maxFirst = GetFirst(_maxList);
                var minFirst = GetFirst(_minList);
                result = (float)(minFirst + maxFirst) / 2;
            }
            else if (_maxList.Count == _minList.Count + 1)
            {
                result = GetFirst(_maxList);
            }
            else if (_maxList.Count + 1 == _minList.Count)
            {
                throw new Exception("the maxList count should equal or greater than the minList");
            }
            return result;
        }
    }
}
