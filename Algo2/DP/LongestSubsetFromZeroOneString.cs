using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DP
{
    //Given 0 and 1 string array, return longest subset have zero and one numbers.
    public class LongestSubsetFromZeroOneString
    {
        public static int GetLongestSubSetByBackTracking(string[] arr, int zeroNumbers, int oneNumbers)
        { 
            if(arr == null || arr.Length == 0 || zeroNumbers < 0 || oneNumbers < 0)
            {
                return 0;
            }

            var tuples = ConvertToTuples(arr);
            int result = 0;
            var selected = new bool[tuples.Count];
            GetLongestSubSetByBackTrackingHelp(tuples, selected, 0, zeroNumbers, oneNumbers, ref result);
            return result;
        }

        public static void GetLongestSubSetByBackTrackingHelp(List<Tuple<int, int>> tuples, bool[] selected, int index, int zeroNumbers, int oneNumbers, ref int result)
        {
            var totalZero = 0;
            var totalOne = 0;
            var selectedCount = 0;
            for (var i = 0; i < selected.Length; i++)
            {
                if (selected[i])
                {
                    totalZero += tuples[i].Item1;
                    totalOne += tuples[i].Item2;
                    selectedCount++;
                }
            }
            if (totalZero <= zeroNumbers && totalOne <= oneNumbers)
            {
                if (selectedCount > result)
                {
                    result = selectedCount;
                }
            }
            if (totalZero > zeroNumbers || totalOne > oneNumbers)
            {
                return;
            }

            for (var i = index; i < tuples.Count; i++)
            {
                selected[i] = true;
                GetLongestSubSetByBackTrackingHelp(tuples, selected, index + 1, zeroNumbers, oneNumbers, ref result);
                selected[i] = false;
            }
        }

        public static int GetLongestSubSetByDp(string[] arr, int zeroNumbers, int oneNumbers)
        {
            if (arr == null || arr.Length == 0 || zeroNumbers < 0 || oneNumbers < 0)
            {
                return 0;
            }

            var tuples = ConvertToTuples(arr);
            var dp = new int[arr.Length + 1, zeroNumbers + 1, oneNumbers + 1];    //each item means use the first i items to get m zero and n one.
            for (var i = 1; i < tuples.Count + 1; i++)
            {
                for (var j = 0; j < zeroNumbers + 1; j++)
                {
                    for (var k = 0; k < oneNumbers + 1; k++)
                    {
                        dp[i, j, k] = dp[i - 1, j, k];
                        var candidateJ = j - tuples[i - 1].Item1;
                        var candidateK = k - tuples[i - 1].Item2;
                        if (candidateJ >= 0 && candidateK >= 0)
                        {
                            var notTaken = dp[i - 1, j, k];
                            var taken = dp[i - 1, candidateJ, candidateK] + 1;
                            dp[i, j, k] = Math.Max(taken, notTaken);
                        }
                    }
                }
            }
            return dp[arr.Length, zeroNumbers, oneNumbers];
        }

        private static List<Tuple<int, int>> ConvertToTuples(string[] arr)
        { 
            var result = new List<Tuple<int, int>>();
            foreach (var item in arr)
            {
                var zero = 0; 
                var one = 0;
                foreach(var c in item)
                {
                    if (c == '0')
                    {
                        zero++;
                    }
                    else if (c == '1') 
                    {
                        one++;
                    }
                }
                var t = new Tuple<int, int>(zero, one);
                result.Add(t);
            }
            return result;
        }
    }
}
