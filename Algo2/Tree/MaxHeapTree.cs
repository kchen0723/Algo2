using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Tree
{
    public class MaxHeapTree
    {
        public List<int> _maxHeap = new List<int>();
        public int Count { get { return _maxHeap.Count; } }

        public MaxHeapTree() 
        { 
        }

        public MaxHeapTree(int[] arr)
        {
            var middle = arr.Length / 2 - 1;
            _maxHeap = arr.ToList();
            for(var i = middle; i >= 0; i--)
            {
                Heapify(i);
            }
        }

        public void Insert(int item)
        { 
            _maxHeap.Add(item);

            var index = _maxHeap.Count - 1;
            while (_maxHeap[index] > _maxHeap[(index - 1) / 2])
            {
                var half = (index - 1) / 2;
                var temp = _maxHeap[index];
                _maxHeap[index] = _maxHeap[half];
                _maxHeap[half] = temp;
                index = half;
            }
        }

        public int Delete()
        {
            if (_maxHeap.Count == 0)
            {
                throw new ApplicationException("heap is empty");
            }
            var result = _maxHeap[0];
            _maxHeap[0] = _maxHeap[_maxHeap.Count - 1];
            _maxHeap.RemoveAt(_maxHeap.Count - 1);
            Heapify(0);

            return result;
        }

        private void Heapify(int index)
        {
            while (true)
            {
                var leftIndex = 2 * index + 1;
                var rightIndex = 2 * index + 2;
                var maxIndex = index;
                if(leftIndex < _maxHeap.Count && _maxHeap[leftIndex] > _maxHeap[maxIndex])
                {
                    maxIndex = leftIndex;
                }
                if (rightIndex < _maxHeap.Count && _maxHeap[rightIndex] > _maxHeap[maxIndex])
                {
                    maxIndex = rightIndex;
                }
                if(maxIndex == index)
                {
                    break;
                }

                var temp = _maxHeap[index];
                _maxHeap[index] = _maxHeap[maxIndex];
                _maxHeap[maxIndex] = temp;

                index = maxIndex;
            }
        }
    }
}
