using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DP
{
    public class LongestIncrement
    {
        //Get Continuous Longest Incremental
        public static int GetContinuousLongestIncremental(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            { 
                return 0;
            }

            var dp = new int[numbers.Length];   //each dp means the continuous longest incremental array 
            dp[0] = 1;                          // base case
            for(var i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] >= numbers[i - 1])         //transfer formula
                {
                    dp[i] = dp[i - 1] + 1;
                }
                else
                {
                    dp[i] = 1;
                }
            }
            return dp.Max();
        }
    }
}
