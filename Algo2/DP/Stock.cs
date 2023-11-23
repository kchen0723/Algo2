using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DP
{
    public class Stock
    {
        public static int GetMaxProfitByDp(List<int> nums)
        {
            if (nums == null || nums.Count == 0)
            {
                return 0;
            }

            var dp = new int[nums.Count, 2];       //At beginning we have 0 money. first row means money after selling stock. second row means money buying stock
            dp[0, 0] = 0;                          //base case, no stock to sell, so the profit is 0. At beginning no stock to sell, so it is 0.
            dp[0, 1] = 0 - nums[0];                //base case. after buying stock, now the profit is 0 - nums[0]
            for (var i = 1; i < nums.Count; i++)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + nums[i]);  //Transfer formula, previous item or money after selling stock.
                dp[i, 1] = Math.Max(dp[i - 1, 1], 0 - nums[i]);             //Transfer formula. previous item or money after buying stock.
            }
            return dp[nums.Count - 1, 0];
        }

        public static int GetMaxProfitByDp2(List<int> nums)
        {
            if (nums == null || nums.Count == 0)
            {
                return 0;
            }

            var dp = new int[nums.Count];    //each item means the max profile till this element.
            for (var i = 1; i < nums.Count; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    dp[i] = Math.Max(dp[i], nums[i] - nums[j]);
                }
            }
            return dp.Max();
        }
    }
}
