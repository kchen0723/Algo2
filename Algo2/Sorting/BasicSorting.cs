using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Sorting
{
    public class BasicSorting
    {
        public static int[] BubbleSort(int[] input)
        {
            if (input == null || input.Length == 0)
            {
                return input;
            }

            for(var i = 0; i < input.Length; i++)
            {
                for (var j = i + 1; j < input.Length; j++)
                {
                    if (input[j] < input[i])
                    {
                        var temp = input[i];
                        input[i] = input[j];
                        input[j] = temp;
                    }
                }
            }
            return input;
        }

        public static int[] SelectionSort(int[] input)
        {
            if (input == null || input.Length == 0)
            {
                return input;
            }

            for(var i = 0; i < input.Length; i++)
            {
                var minIndex = i;
                for (var j = i + 1; j < input.Length; j++)
                {
                    if (input[minIndex] > input[j])
                    {
                        minIndex = j;
                    }
                }
                var temp = input[i];
                input[i] = input[minIndex];
                input[minIndex] = temp;
            }
            return input;
        }

        public static int[] InsertionSort(int[] input)
        {
            if (input == null || input.Length == 0)
            {
                return input;
            }

            for (var i = 0; i < input.Length; i++)
            {
                var currentValue = input[i];
                var j = i;
                while (j > 0 && input[j - 1] > currentValue)
                {
                    input[j] = input[j - 1];
                    j--;
                }
                input[j] = currentValue;
            }
            return input;
        }
    }
}
