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
                for (var j = i; j < input.Length; j++)
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
    }
}
