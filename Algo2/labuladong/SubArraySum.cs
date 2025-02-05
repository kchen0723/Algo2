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

        public static int SubArraySumCountByDirectory(int[] array, int target)
        {
            if (array == null || array.Length == 0)
            {
                return 0;
            }

            int count = 0;
            var sum = 0;
            var sumDictionary = new Dictionary<int, int>();
            sumDictionary.Add(0, 1);
            for(var i = 0; i < array.Length; i++)
            {
                sum += array[i];
                var residual = sum - target;
                if (sumDictionary.ContainsKey(residual))
                {
                    count++;
                    sumDictionary[residual] = sumDictionary[residual] + 1;
                }
                else
                {
                    sumDictionary.Add(residual, 1);
                }
            }   
            return count;
        }
    }
}
