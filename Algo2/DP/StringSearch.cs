using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DP
{
    public class StringSearch
    {
        public static int BruteSearch(string text, string pattern)
        {
            if (text == null || pattern == null)
            {
                return -1;
            }
            if (pattern.Length == 0)
            {
                return 0;
            }

            var i = 0;
            var j = 0;
            while(i < text.Length && j < pattern.Length)
            {
                if (text[i] == pattern[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    i = i - j + 1;
                    j = 0;
                }
            }

            if (j == pattern.Length)
            {
                return i - j;
            }
            return -1;
        }

        //https://www.qb5200.com/article/587614.html
        private static int[] LongestCommonPrePostfix(string pattern)
        {
            int[] next = new int[pattern.Length];
            var longestCommonPrePostfixLength = 0;
            for (int i = 1; i < pattern.Length; i++)
            {
                while (longestCommonPrePostfixLength > 0 && pattern[i] != pattern[longestCommonPrePostfixLength])
                {
                    longestCommonPrePostfixLength = next[longestCommonPrePostfixLength - 1];
                }
                if (pattern[i] == pattern[longestCommonPrePostfixLength])
                {
                    longestCommonPrePostfixLength++;
                }
                next[i] = longestCommonPrePostfixLength;
            }
            return next;
        }

        private static int[] LongestCommonPrePostfix2(string pattern)
        {
            int[] next = new int[pattern.Length];
            for (var i = 1; i < pattern.Length; i++)
            {
                for (var longestCommonPrePostfixLength = i; longestCommonPrePostfixLength > 0; longestCommonPrePostfixLength--)
                {
                    var isMatch = true;
                    for (var j = 0; j < longestCommonPrePostfixLength; j++)
                    {
                        if (pattern[j] != pattern[i - longestCommonPrePostfixLength + j + 1])
                        {
                            isMatch = false;
                            break;
                        }
                    }
                    if (isMatch == true)
                    {
                        next[i] = longestCommonPrePostfixLength;
                        break;
                    }
                }
            }
            return next;
        }

        public static int KmpSearch(string text, string pattern)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(pattern))
            {
                return -1;
            }
            var next = LongestCommonPrePostfix(pattern);
            var longestCommonPrePostfixLength = 0;
            for (int i = 0; i < text.Length; i++)
            {
                while (longestCommonPrePostfixLength > 0 && text[i] != pattern[longestCommonPrePostfixLength])
                {
                    longestCommonPrePostfixLength = next[longestCommonPrePostfixLength - 1];
                }
                if (text[i] == pattern[longestCommonPrePostfixLength])
                {
                    longestCommonPrePostfixLength++;
                }
                if (longestCommonPrePostfixLength == pattern.Length)
                {
                    return i - longestCommonPrePostfixLength + 1;
                }
            }
            return -1;
        }
    }
}
