using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algo2.DP
{
    //return how many wasy to change coins.
    public class CoinChange
    {
        public static int GetMinCountByDp(int[] coins, int money)
        {
            if (coins == null || coins.Length == 0 || money == 0)
            { 
                return 0; 
            }

            var dp = new int[money + 1];
            var candidte = new List<int>();
            Array.Sort(coins);
            for (var i = coins[0]; i <= money; i++)
            {
                candidte.Clear();
                foreach (var coin in coins)
                {
                    if (i > coin)
                    {
                        candidte.Add(dp[i - coin]);
                    }
                    else if (i == coin)
                    {
                        candidte.Add(0);
                    }
                }
                var min = candidte.Min();
                dp[i] = min + 1;
            }
            return dp[money];
        }

        public static int GetMinCountByDp2(int[] coins, int money)
        {
            if (coins == null || coins.Length == 0 || money <= 0)
            {
                return 0;
            }

            var dp = new int[money + 1];
            var candidte = new List<int>();
            for (var i = 0; i <= money; i++)
            {
                candidte.Clear();
                for (var j = 0; j < coins.Length; j++)
                {
                    if (i > coins[j])
                    {
                        candidte.Add(1 + dp[i - coins[j]]);
                    }
                }
                if (candidte.Count > 0)
                {
                    dp[i] = candidte.Min();
                }
            }
            return dp[money];
        }

        public static Tuple<int, List<List<int>>> GetMinCountByBackTrack(int[] coins, int money)
        {
            var result = int.MaxValue;
            var resultCoins = new List<List<int>>();
            if (coins == null || coins.Length == 0 || money == 0)
            {
                new Tuple<int, List<List<int>>>(0, resultCoins);
            }

            Array.Sort(coins);
            var candidate = new List<int>();
            GetMinCountHelp(coins, money, 0, candidate, ref result, resultCoins);
            return new Tuple<int, List<List<int>>>(result, resultCoins);
        }

        private static void GetMinCountHelp(int[] coins, int money, int index, List<int> candidate, ref int result, List<List<int>> resultCoins)
        { 
            if(candidate.Sum() == money)
            {
                if (candidate.Count < result)
                { 
                    result = candidate.Count;
                    resultCoins.Add(candidate.ToArray().ToList());
                }
                return;
            }
            if(candidate.Sum() > money)
            {
                return;
            }

            for (var i = index; i < coins.Length; i++)
            {
                candidate.Add(coins[i]);
                GetMinCountHelp(coins, money, index, candidate, ref result, resultCoins);
                candidate.RemoveAt(candidate.Count - 1);
            }
        }
    }
}
