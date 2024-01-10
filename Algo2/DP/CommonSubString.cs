using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DP
{
    public class CommonSubString
    {
        public static string GetLongestCommonSubStringByDp(string left, string right)
        {
            if (left == null || right == null || left.Length == 0 || right.Length == 0)
            {
                return string.Empty;
            }
            
            var dp = new int[left.Length + 1, right.Length + 1];  //each item means the longest common string till the m left and n right
            var result = string.Empty;
            for(var i = 1; i < left.Length + 1; i++)
            {
                for (var j = 1; j < right.Length + 1; j++)
                {
                    if (left[i - 1] == right[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;           //transfer formula
                        if (dp[i, j] > result.Length)
                        { 
                            result = left.Substring(i - dp[i, j], dp[i, j]);
                        }
                    }
                }
            }
            return result;
        }
    }
}
