using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DP
{
    public class CommonSubString
    {
        public static int GetLongestCommonSubString(string left, string right)
        {
            if (left == null || right == null || left.Length == 0 || right.Length == 0)
            {
                return 0;
            }
            
            var dp = new int[left.Length + 1, right.Length + 1];  //each item means the longest common string till the m left and n right
            for(var i = 1; i < left.Length + 1; i++)
            {
                for (var j = 1; j < right.Length + 1; j++)
                {
                    if (left[i - 1] == right[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;           //transfer formula
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j - 1];              //transfer formula
                    }
                }
            }
            return dp[left.Length, right.Length];
        }
    }
}
