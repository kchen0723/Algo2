using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.labuladong
{
    public class LongestPalindrome
    {
        //https://blog.csdn.net/afei__/article/details/83214042
        //https://www.cnblogs.com/clarino/p/12417000.html
        public static string GetLongestPalindromeStringDp(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            var dp = new int[str.Length, str.Length];
            var result = str[0].ToString();
            for (var i = 0; i < str.Length; i++)
            {
                for (var j = i; j >= 0; j--)
                {
                    dp[i, j] = 1;
                    if (str[i] == str[j])
                    {
                        if (i - 1 >= 0 && j + 1 <= i)
                        {
                            dp[i, j] = dp[i - 1, j + 1] + 2;
                        }
                        if (dp[i, j] > result.Length)
                        {
                            result = str.Substring(j, i - j + 1);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return result;
        }

        //here the longest palindrome subset just return the length, not the subset itself.
        public static int GetLongestPalindromeSubsetDp(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            var dp = new int[str.Length, str.Length];
            var result = 1;
            for (var i = 0; i < str.Length; i++)
            {
                for (var j = i; j >= 0; j--)
                {
                    dp[i, j] = 1;
                    if (str[i] == str[j])
                    {
                        dp[i, j] = dp[i - 1, j + 1] + 2; 
                    }
                    else
                    {
                        if (i - 1 >= 0 && j + 1 <= i)
                        {
                            var left = dp[i - 1, j];
                            var right = dp[i, j + 1];
                            dp[i, j] = Math.Max(left, right);
                        }
                    }
                    result = Math.Max(result, dp[i, j]);
                }
            }
            return result;
        }

        public static string GetLongestPalindromeString(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            var result = string.Empty;
            for (var i = 0; i < str.Length; i++)
            {
                var even = GetPalindrome(str, i, i + 1);
                var odd = GetPalindrome(str, i, i);
                if (even.Length > result.Length)
                { 
                    result = even;
                }
                if (odd.Length > result.Length)
                {
                    result = odd;
                }
            }
            return result;
        }

        private static string GetPalindrome(string str, int start, int end)
        {
            while (start >= 0 && end < str.Length && str[start] == str[end])
            { 
                start--;
                end++;
            }
            return str.Substring(start + 1, end - start - 1);
        }
    }
}
