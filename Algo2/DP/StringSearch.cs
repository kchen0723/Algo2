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
        private static int[] KmpNext(string pattern)
        {
            int[] next = new int[pattern.Length];
            for (int i = 1, j = 0; i < pattern.Length; i++)
            {
                while (j > 0 && pattern[i] != pattern[j])
                {
                    j = next[j - 1];
                }
                if (pattern[i] == pattern[j])
                {
                    j++;
                }
                next[i] = j;
            }
            return next;
        }

        public static int KmpSearch(string text, string pattern)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(pattern))
            {
                return -1;
            }
            var next = KmpNext(pattern);
            for (int i = 0, j = 0; i < text.Length; i++)
            {
                while (j > 0 && text[i] != pattern[j])
                {
                    j = next[j - 1];
                }
                if (text[i] == pattern[j])
                {
                    j++;
                }
                if (j == pattern.Length)
                {
                    return i - j + 1;
                }
            }
            return -1;
        }
    }
}
