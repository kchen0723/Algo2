using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.labuladong
{
    public class LongestPalindrome
    {
        public static int GetLongestPalindromeSubset(string str)
        {
            if (string.IsNullOrEmpty(str))
            { 
                return -1;
            }

            var reversedString = new string(str.Reverse().ToArray());
            var dp = new int[str.Length + 1, str.Length + 1];  //now try to find longest common subset between str and reversedString
            var result = 0;
            for(var i = 1; i < str.Length + 1; i++)
            {
                for (var j = 1; j < reversedString.Length + 1; j++)
                {
                    if (str[i - 1] == reversedString[j - 1])  //the char is same, so common subset should be add one
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                        result = Math.Max(dp[i, j], result);
                    }
                }
            }
            return result;
        }
    }
}
