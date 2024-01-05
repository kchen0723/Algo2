using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Pramp
{
    public class ReverseWords
    {
        public static string Reverse(string words)
        {
            if (string.IsNullOrEmpty(words))
            {
                return words;
            }

            var wordsArray = words.ToCharArray();
            var start = 0;
            var end = 0;
            while (end < wordsArray.Length)
            {
                if (wordsArray[end] == ' ')
                { 
                    ReverseHelp(wordsArray, start, end - 1);
                    start = end + 1;
                }
                end++;
            }
            ReverseHelp(wordsArray, start, wordsArray.Length - 1);
            ReverseHelp(wordsArray, 0, wordsArray.Length - 1);
            return new string(wordsArray);
        }

        private static void ReverseHelp(char[] words, int start, int end)
        {
            if(start >= 0 && end < words.Length)
            {
                while(start < end)
                {
                    var temp = words[start];
                    words[start] = words[end];
                    words[end] = temp;
                    start++;
                    end--;
                }
            }
        }
    }
}
