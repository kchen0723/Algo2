using Algo2.DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.labuladong
{
    public class Rectangle
    { 
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class EnvelopNest
    {
        public static int MaxNestCount(Rectangle[] rectangles)
        {
            if (rectangles == null || rectangles.Length == 0)
            {
                return 0;
            }

            var sorted = rectangles.OrderBy(item => item.Width).ThenBy(item => item.Height).ToArray();
            //var sorted = rectangles;
            var dp = new int[sorted.Length];
            for(var i = 0; i < sorted.Length; i++)
            {
                dp[i] = 1;
                for (var j = 0; j < i; j++)
                {
                    if (sorted[i].Width > sorted[j].Width && sorted[i].Height > sorted[j].Height)
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }
            return dp.Max();
        }   
    }
}
