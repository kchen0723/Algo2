using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.BinarySearch
{
    public class BinarySearch
    {
        public static int FindInSortedUniqueArray(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0)
            {
                return -1;
            }

            var start = 0;
            var end = arr.Length - 1;
            while (start <= end)
            {
                var middle = start + (end - start) / 2;
                if (arr[middle] < target)
                {
                    start = middle + 1;
                }
                else if (arr[middle] == target)
                {
                    return middle;
                }
                else if (arr[middle] > target)
                {
                    end = middle - 1;
                }
            }
            return -1;
        }

        public static int FindLeftBoundaryInSortedArray(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0)
            {
                return -1;
            }

            var start = 0;
            var end = arr.Length - 1;
            while (start <= end)
            {
                var middle = start + (end - start) / 2;
                if (arr[middle] < target)
                {
                    start = middle + 1;
                }
                else if (arr[middle] == target)
                {
                    end = middle - 1;
                }
                else if (arr[middle] > target)
                {
                    end = middle - 1;
                }
            }

            if (start < arr.Length && arr[start] == target)
            {
                return start;
            }
            return -1;
        }

        public static int FindRightBoundaryInSortedArray(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0)
            {
                return -1;
            }

            var start = 0;
            var end = arr.Length - 1;
            while (start <= end)
            {
                var middle = start + (end - start) / 2;
                if (arr[middle] < target)
                {
                    start = middle + 1;
                }
                else if (arr[middle] == target)
                {
                    start = middle + 1;
                }
                else if (arr[middle] > target)
                {
                    end = middle - 1;
                }
            }

            if (end >= 0 && arr[end] == target)
            {
                return end;
            }
            return -1;
        }
    }
}
