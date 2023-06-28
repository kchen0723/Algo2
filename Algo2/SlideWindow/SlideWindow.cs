using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.SlideWindow
{
    public class SlideWindow
    {
        public static string GetMinCover(string source, string target)
        {
            var left = 0;
            var right = 0;
            var start = 0;
            var length = source.Length;
            var matchCount = 0;
            var window = new Dictionary<char, int>();
            var targetDictionary = BuildDictionary(target);
            for (; right < source.Length; right++)
            { 
                var item = source[right];
                if (targetDictionary.ContainsKey(item))
                {
                    if (window.ContainsKey(item))
                    {
                        window[item] += 1;
                    }
                    else
                    {
                        window.Add(item, 1);
                    }
                    if (window[item] == targetDictionary[item])
                    {
                        matchCount++;
                    }
                }

                while (matchCount == target.Length)
                {
                    if (right - left + 1 < length)
                    {
                        start = left;
                        length = right - left + 1;
                    }

                    var removeCandidate = source[left];
                    left++;
                    if (window.ContainsKey(removeCandidate))
                    {
                        if (window[removeCandidate] == targetDictionary[removeCandidate])
                        {
                            matchCount--;
                        }
                        window[removeCandidate] -= 1;
                    }
                }
            }

            if (length < source.Length)
            { 
                return source.Substring(start, length);
            }
            return string.Empty;
        }

        public static Dictionary<char, int> BuildDictionary(string target)
        { 
            var result = new Dictionary<char, int>();
            foreach (var item in target)
            {
                if (result.ContainsKey(item))
                {
                    result[item] += 1;
                }
                else
                { 
                    result.Add(item, 1);
                }
            }
            return result;
        }

        public static bool HasPermutation(string source, string target)
        {
            var left = 0;
            var right = 0;
            var matchCount = 0;
            var window = new Dictionary<char, int>();
            var targetDictionary = BuildDictionary(target);
            for (; right < source.Length; right++)
            {
                var item = source[right];
                if (targetDictionary.ContainsKey(item))
                {
                    if (window.ContainsKey(item))
                    {
                        window[item] += 1;
                    }
                    else
                    {
                        window.Add(item, 1);
                    }
                    if (window[item] == targetDictionary[item])
                    {
                        matchCount++;
                    }
                }

                while (matchCount == target.Length)
                {
                    if (right - left + 1 == target.Length)
                    {
                        return true;
                    }

                    var removeCandidate = source[left];
                    left++;
                    if (window.ContainsKey(removeCandidate))
                    {
                        if (window[removeCandidate] == targetDictionary[removeCandidate])
                        {
                            matchCount--;
                        }
                        window[removeCandidate] -= 1;
                    }
                }
            }
            return false;
        }

        public static bool HasPermutationByBitXOR(string source, string target)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(target) || source.Length < target.Length)
            { 
                return false;
            }

            for (var i = 0; i <= source.Length - target.Length; i++)
            {
                var sub = source.Substring(i, target.Length);
                if (IsPermutation(sub, target))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsPermutation(string sub, string target) 
        {
            var bit = 0;
            if (sub.Length == target.Length)
            {
                for (var i = 0; i < sub.Length; i++)
                {
                    bit ^= sub[i];
                    bit ^= target[i];
                }
            }
            return bit == 0;
        }
    }
}
