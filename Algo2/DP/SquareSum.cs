using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DP
{
    public class SquareSum
    {
        public static int GetMinSquareCountByDp(int num)
        {
            if (num < 1)
            {
                return 0;
            }

            var dp = new int[num + 1];     //each item means the count for that item
            for(var i = 1; i <= num; i++)
            {
                var root = (int)Math.Floor(Math.Sqrt(i));
                if (i == root * root)
                {
                    dp[i] = 1;                //transfer formula
                }
                else
                {
                    dp[i] = dp[root * root] + dp[i - root * root];     //transfer formula
                }
            }
            return dp[num];
        }
    }
}
