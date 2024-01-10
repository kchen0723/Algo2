using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DP
{
    public class TriangleMinPath
    {
        public static int GetMinPathByDp(List<List<int>> triangle)
        {
            if (triangle == null || triangle.Count == 0)
            {
                return 0;
            }

            var dp = new List<List<int>>(); //each item means the min path to that layer from the bottom.
            dp.Add(triangle[triangle.Count - 1]);  //base case, add the bottom layer to dp.
            for (var i = triangle.Count - 2; i >= 0; i--)
            {
                var layer = new List<int>();
                for (var j = 0; j < triangle[i].Count; j++)
                {
                    var left = triangle[i][j] + dp[0][j];         //transfer formula
                    var right = triangle[i][j] + dp[0][j + 1];
                    layer.Add(Math.Min(left, right));
                }
                dp.Insert(0, layer);  
            }

            return dp[0].Min();
        }
    }
}
