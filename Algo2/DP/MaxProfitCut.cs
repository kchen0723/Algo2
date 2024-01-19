using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DP
{
    public class MaxProfitCut
    {
        public static int GetMaxProfitByBackTracking(int[] sections, int[] profits, int length)
        {
            if (sections == null || sections.Length == 0 || profits == null || profits.Length == 0 || sections.Length != profits.Length)
            {
                return 0;
            }

            int result = 0;
            List<Tuple<int, int>> tuples = new List<Tuple<int, int>>();
            for (var i = 0; i < sections.Length; i++)
            { 
                var tuple = new Tuple<int, int>(sections[i], profits[i]);
                tuples.Add(tuple);
            }
            var selected = new List<Tuple<int, int>>();
            GetMaxProfitByBackTrackingHelp(tuples, selected, length, ref result);
            return result;
        }

        public static void GetMaxProfitByBackTrackingHelp(List<Tuple<int, int>> tuples, List<Tuple<int, int>> selected, int length, ref int result)
        {
            var selectedLength = 0;
            var selectedProfit = 0;
            foreach(var item in selected)
            {
                selectedLength += item.Item1;
                selectedProfit += item.Item2;
            }
            if(selectedLength > length)
            {
                return;
            }
            if(selectedLength == length)
            {
                result = Math.Max(result, selectedProfit);
                return;
            }

            for(var i = 0; i < tuples.Count; i++)
            {
                selected.Add(tuples[i]);
                GetMaxProfitByBackTrackingHelp(tuples, selected, length, ref result);
                selected.RemoveAt(selected.Count - 1);
            }
        }

        public static int GetMaxProfitByDp(int[] sections, int[] profits, int length)
        {
            if (sections == null || sections.Length == 0 || profits == null || profits.Length == 0 || sections.Length != profits.Length)
            {
                return 0;
            }

            var dp = new int[length + 1];
            for(var i = 1; i < dp.Length; i++ )
            {
                for (var j = 0; j < sections.Length; j++)
                {
                    if (i >= sections[j])
                    {
                        var current = dp[i - sections[j]] + profits[j];
                        dp[i] = Math.Max(dp[i], current);
                    }
                }
            }
            return dp[length];
        }
    }
}
