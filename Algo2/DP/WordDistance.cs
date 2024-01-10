using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DP
{
    public class WordDistance
    {
        //Get Insert and Delete Distance
        public static int GetInsertDeleteDistanceByDp(string src, string dst)
        {
            if (src == null || dst == null)
            { 
                return 0; 
            }

            var dp = new int[src.Length + 1, dst.Length + 1];  // 1) define each src --> dst distance
            for (var i = 0; i <= src.Length; i++)
            {
                for (var j = 0; j <= dst.Length; j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = j;                       // 2)　base case
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = i;                       // 2)　base case
                    }
                    else if (src[i - 1] == dst[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];         // 3) transfer formula
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + 1;         // 3) transfer formula, left is for insert, top is for delete
                    }
                }
            }
            return dp[src.Length, dst.Length];
        }

        //Get Edit Distance(insert, delete and edit)
        public static int GetEditDistanceByDp(string src, string dst)
        {
            if (src == null || dst == null)
            {
                return 0;
            }

            var dp = new int[src.Length + 1, dst.Length + 1];
            for (var i = 0; i <= src.Length; i++)
            {
                for (var j = 0; j <= dst.Length; j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = j;
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = i;
                    }
                    else if (src[i - 1] == dst[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];       // 3) transfer formula
                    }
                    else
                    {
                        var left = dp[i - 1, j];
                        var top = dp[i, j - 1];
                        var leftTop = dp[i - 1, j - 1];
                        dp[i, j] = new int[] { left, top, leftTop }.Min() + 1;   // 3) transfer formula, left is for insert, top is for delete, left top is for edit
                    }
                }
            }
            return dp[src.Length, dst.Length];
        }
    }
}
