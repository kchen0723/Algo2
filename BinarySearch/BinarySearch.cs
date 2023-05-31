using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.BinarySearch
{
    public class BinarySearch
    {
        public static int FindInUniqueSortedArray(int[] sortedArray, int target)
        {
            if (sortedArray == null || sortedArray.Length == 0)
            {
                return -1;
            }

            var start = 0;
            var end = sortedArray.Length - 1;
            while (start <= end)
            {
                var middle = start + (end - start) / 2;
                var current = sortedArray[middle];
                if (current < target)
                {
                    start = middle + 1;
                }
                else if (current == target)
                {
                    return middle;
                }
                else if (current > target)
                {
                    end = middle - 1;
                }
            }
            return -1;
        }
    }
}
