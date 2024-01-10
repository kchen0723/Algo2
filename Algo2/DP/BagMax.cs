using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DP
{
    public class BagMax
    {
        public static int GetMaxProfitForWeightByBackTracking(int[,] bags, int maxWeight)
        {
            if (bags == null || bags.Length == 0 || maxWeight <= 0)
            {
                return 0;
            }

            var selected = new bool[bags.GetLength(0)];
            var result = 0;
            GetMaxProfitForWeightByBackTrackingHelper(bags, maxWeight, selected, 0, ref result);
            return result;
        }

        private static void GetMaxProfitForWeightByBackTrackingHelper(int[,] bags, int maxWeight, bool[] selected, int index, ref int result)
        {
            var selectedWeight = 0;
            var selectedProfit = 0;
            for(var i = 0; i < selected.Length; i++)
            {
                if (selected[i])
                {
                    selectedWeight += bags[i, 0];
                    selectedProfit += bags[i, 1];
                }
            }
            if (selectedWeight <= maxWeight)
            {
                result = Math.Max(result, selectedProfit);
            }
            if (selectedWeight >= maxWeight)
            {
                return;
            }
            

            for(var i = index; i < bags.GetLength(0); i++)
            {
                if (selected[i])
                {
                    continue;
                }
                selected[i] = true;
                GetMaxProfitForWeightByBackTrackingHelper(bags, maxWeight, selected, i + 1, ref result);
                selected[i] = false;
            }
        }

        public static int GetMaxProfitForWeightByDp(int[,] bags, int maxWeight)
        {
            if (bags == null || bags.Length == 0 || maxWeight <= 0)
            {
                return 0;
            }

            var dp = new int[bags.GetLength(0) + 1, maxWeight + 1];   //each item means the first N bags for M weight.
            for (var i = 0; i < bags.GetLength(0) + 1; i++)           //for each bags
            {
                for (var j = 0; j < maxWeight + 1; j++)               //for each weight
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;                                //base case
                    }
                    else if (j >= bags[i - 1, 0])
                    {
                        var taken = bags[i - 1, 1] + dp[i - 1, j - bags[i - 1, 0]];
                        var notTaken = dp[i - 1, j];
                        dp[i, j] = Math.Max(taken, notTaken);        //transfer formula
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];                      //transfer formula
                    }
                }
            }
            return dp[bags.GetLength(0), maxWeight];
        }

        public static int GetMaxProfitForWeightByDpMultiple(int[,] bags, int maxWeight)
        {
            if (bags == null || bags.Length == 0 || maxWeight <= 0)
            {
                return 0;
            }

            var dp = new int[maxWeight + 1];          //each item means the first N weight.
            var candidate = new List<int>();
            for (var i = 0; i < maxWeight + 1; i++)           //for each weight
            {
                candidate.Clear();
                for (var j = 0; j < bags.GetLength(0); j++)
                {
                    if (i >= bags[j, 0])
                    {
                        var notTaken = dp[i - 1];
                        var taken = bags[j, 1] + dp[i - bags[j, 0]];
                        candidate.Add(Math.Max(taken, notTaken));   //transfer formula
                    }
                }
                if (candidate.Count > 0)
                {
                    dp[i] = candidate.Max();
                }
            }
            return dp[maxWeight];
        }
    }
}
