using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Sorting
{
    public class AdvancedSorting
    {
        public static int[] ShellSort(int[] input)
        {
            if (input == null || input.Length == 0)
            {
                return input;
            }

            for(var gap = input.Length / 2; gap > 0; gap /= 2)
            {
                for (var i = gap; i < input.Length; i+= gap)
                { 
                    int temp = input[i];
                    var j = i;
                    for (; j >= gap && input[j - gap] >= temp; j -= gap)
                    {
                        input[j] = input[j - gap];
                    }
                    input[j] = temp;
                }
            }
            return input;
        }

        public static int[] QuickSort(int[] input)
        {
            if (input == null || input.Length == 0)
            {
                return input;
            }

            QuickSortHelper(input, 0, input.Length - 1);
            return input;
        }

        private static void QuickSortHelper(int[] input, int left, int right)
        {
            if(left < right)
            {
                int low = left;
                int high = right;
                while (low < high)
                {
                    while (low < right && input[low] <= input[left])
                    {
                        low++;
                    }
                    while (high > left && input[high] >= input[left])
                    { 
                        high--;
                    }
                    if (low < high)
                    { 
                        Swap(input, low, high);
                    }
                }

                Swap(input, left, high);
                QuickSortHelper(input, left, high - 1);
                QuickSortHelper(input, high + 1, right);
            }
        }

        private static void Swap(int[] input, int left, int right)
        { 
            if(input != null && input.Length > 0 && left >= 0 && right < input.Length)
            {
                var temp = input[left];
                input[left] = input[right];
                input[right] = temp;
            }
        }

        public static void MergeSort(int[] input)
        {
            if (input == null || input.Length == 0)
            {
                return;
            }
            MergeSortHelper(input, 0, input.Length - 1);
        }

        private static void MergeSortHelper(int[] input, int start, int end)
        {
            if (start < end)
            {
                var middle = start + (end - start) / 2;
                MergeSortHelper(input, start, middle);
                MergeSortHelper(input, middle + 1, end);
                Merge2SortedHalvesArray(input, start, middle, end);
            }
        }

        public static void Merge2SortedHalvesArray(int[] input, int left, int leftEnd, int rightEnd)
        {
            var leftLength = leftEnd - left + 1;
            var rightLength = rightEnd - leftEnd;
            var leftPart = new int[leftLength];
            var rightPart = new int[rightLength];
            Array.Copy(input, left, leftPart, 0, leftLength);
            Array.Copy(input, leftEnd + 1, rightPart, 0, rightLength);

            var i = 0;
            var j = 0;
            var k = left;
            while (i < leftLength && j < rightLength)
            {
                if (leftPart[i] <= rightPart[j])
                {
                    input[k] = leftPart[i];
                    i++;
                }
                else
                {
                    input[k] = rightPart[j];
                    j++;
                }
                k++;
            }

            while (i < leftLength)
            {
                input[k] = leftPart[i];
                i++;
                k++;
            }
            while (j < rightLength)
            {
                input[k] = rightPart[j];
                j++;
                k++;
            }
        }
    }
}
