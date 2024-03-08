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
    }
}
