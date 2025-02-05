using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.labuladong
{
    public class SubArraySum
    {
        public static int SubArraySumCount(int[] array, int target)
        {
            if (array == null || array.Length == 0)
            {
                return 0;
            }

            int sum = 0;
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum = 0;
                for (int j = i; j >= 0; j--)
                { 
                    sum += array[j];
                    if (sum == target)
                    { 
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
