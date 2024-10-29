using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.labuladong
{
    public class LongestPalindrome
    {
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
