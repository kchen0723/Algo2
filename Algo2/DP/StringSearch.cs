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

        //https://www.geeksforgeeks.org/kmp-algorithm-for-pattern-searching/
        //https://www.youtube.com/watch?v=GTJr8OvyEVQ
        private static int[] LongestProperPrefixSuffix(string pattern)
        {
            int[] next = new int[pattern.Length];
            var longestProperPrefixSuffixLength = 0;
            var i = 1;
            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[longestProperPrefixSuffixLength])
                {
                    longestProperPrefixSuffixLength++;
                    next[i] = longestProperPrefixSuffixLength;
                    i++;
                }
                else
                {
                    if (longestProperPrefixSuffixLength == 0)
                    {
                        i++;
                    }
                    else
                    { 
                        longestProperPrefixSuffixLength = next[longestProperPrefixSuffixLength - 1];
                    }
                }   
            }   
            return next;
        }

        private static int[] LongestProperPrefixSuffixBruteForce(string pattern)
        {
            int[] next = new int[pattern.Length];
            for (var i = 1; i < pattern.Length; i++)
            {
                for (var longestProperPrefixSuffixLength = i; longestProperPrefixSuffixLength > 0; longestProperPrefixSuffixLength--)
                {
                    var isMatch = true;
                    for (var j = 0; j < longestProperPrefixSuffixLength; j++)
                    {
                        if (pattern[j] != pattern[i - longestProperPrefixSuffixLength + j + 1])
                        {
                            isMatch = false;
                            break;
                        }
                    }
                    if (isMatch == true)
                    {
                        next[i] = longestProperPrefixSuffixLength;
                        break;
                    }
                }
            }
            return next;
        }

        public static int KmpSearch(string text, string pattern)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(pattern) || pattern.Length > text.Length)
            {
                return -1;
            }

            var next = LongestProperPrefixSuffix(pattern);
            var i = 0;
            var longestProperPrefixSuffixLength = 0;
            while(i < text.Length)
            {
                if (text[i] == pattern[longestProperPrefixSuffixLength])
                {
                    i++;
                    longestProperPrefixSuffixLength++;
                    if (longestProperPrefixSuffixLength == pattern.Length)
                    {
                        return i - longestProperPrefixSuffixLength;
                    }
                }
                else
                {
                    if (longestProperPrefixSuffixLength == 0)
                    {
                        i++;
                    }
                    else
                    {
                        longestProperPrefixSuffixLength = next[longestProperPrefixSuffixLength - 1];
                    }
                }
            }

            return -1;
        }
    }
}
