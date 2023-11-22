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

            var dp = new int[nums.Count, 2];    //we have 0 money at beginning. first row means buy stock. second row means sell stock
            dp[0, 0] = nums[0];                 //base case
            dp[0, 1] = 0 - nums[0];
            for (var i = 1; i < nums.Count; i++)
            { 
                
            }
            return 0;
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
