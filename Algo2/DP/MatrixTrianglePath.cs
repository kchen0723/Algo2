using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DP
{
    public class MatrixTrianglePath
    {
        public static int GetMatrixTrianglePathByDp(int num)
        {
            if (num < 0)
            { 
                return 0; 
            }

            var dp = new int[num + 1, num + 1];   //base case
            for(var i = 0; i < num + 1; i++)      //row
            {
                for (var j = 0; j < num + 1; j++)  //column
                {
                    if (i == 0)
                    {
                        dp[i, j] = 1;
                    }
                    else if (i <= j)
                    {
                        dp[i, j] = dp[i -1, j] + dp[i, j - 1];
                    }
                }
            }
            return dp[num, num];
        }
    }
}
