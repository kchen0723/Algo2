using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.BinarySearch
{
    public class BinarySearch
    {
        public static int FindInSortedUniqueArrayRecursive(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0)
            {
                return -1;
            }

            var start = 0;
            var end = arr.Length - 1;
            return FindInSortedUniqueArrayRecursiveHelper(arr, start, end, target);
        }

        private static int FindInSortedUniqueArrayRecursiveHelper(int[] arr, int start, int end, int target)
        {
            if (start >= end)
            {
                return -1;
            }
            var middle = start + (end - start) / 2;
            if (arr[middle] < target)
            {
                return FindInSortedUniqueArrayRecursiveHelper(arr, middle + 1, end, target);
            }
            else if (arr[middle] == target)
            {
                return middle;
            }
            else if (arr[middle] > target)
            {
                return FindInSortedUniqueArrayRecursiveHelper(arr, start, middle, target);
            }
            return -1;
        }

        public static int FindInSortedUniqueArray(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0)
            {
                return -1;
            }

            var start = 0;
            var end = arr.Length - 1;
            return FindInSortedUniqueArray(arr, start, end, target);
        }

        public static int FindInSortedUniqueArray(int[] arr, int start, int end, int target)
        {
            if (arr == null || arr.Length == 0)
            {
                return -1;
            }

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

        public static int FindInSortedShiftArray(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0)
            {
                return -1;
            }

            var maxIndex = GetMaxIndexInSortedShiftArray(arr);
            if (maxIndex == arr.Length - 1)     //actually it is sorted array
            {
                return FindInSortedUniqueArray(arr, target);
            }
            else if (arr[maxIndex] < target)
            {
                return -1;
            }
            else if (arr[maxIndex] == target)
            {
                return maxIndex;
            }
            else if (arr[maxIndex] > target)
            {
                if (arr[0] > target)
                {
                    return FindInSortedUniqueArray(arr, maxIndex + 1, arr.Length - 1, target);
                }
                else if(arr[0] == target)
                {
                    return 0;
                }
                else if(arr[0] < target)
                {
                    return FindInSortedUniqueArray(arr, 0, maxIndex, target);
                }
            }
            return -1;
        }

        private static int GetMaxIndexInSortedShiftArray(int[] arr)
        {
            var start = 0;
            var end = arr.Length - 1;
            while (start <= end)
            {
                var current = arr[start];
                var middle = start + (end - start) / 2;
                if (arr[middle] > current)
                {
                    if (IsEdge(arr, middle))
                    {
                        return middle;
                    }
                    else
                    {
                        start = middle + 1;
                    }
                }
                else if (arr[middle] == current)
                {
                    return middle; //only when arr has one element.
                }
                else if (arr[middle] < current)
                {
                    if (IsEdge(arr, middle))
                    {
                        return middle;
                    }
                    end = middle - 1;
                }
            }
            return arr.Length - 1;
        }

        private static bool IsEdge(int[] arr, int index)
        {
            if (index > 0 && index < arr.Length - 1)
            {
                if (arr[index] > arr[index - 1] && arr[index] > arr[index + 1])
                {
                    return true;
                }
                if (arr[index] < arr[index - 1] && arr[index] < arr[index + 1])
                {
                    return true;
                }
                return false;
            }
            return true;
        }
    }
}
