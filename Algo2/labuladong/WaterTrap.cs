using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.labuladong
{
    public class WaterTrap
    {
        //给定N个非负整数表示每个宽度为1的柱子的高度，计算按此排列的柱子，下雨之后最多能接多少雨水。
        public static int Trap(int[] heights)
        {
            if (heights == null || heights.Length < 3)
            {
                return 0;
            }

            var leftMax = new int[heights.Length];
            var rightMax = new int[heights.Length];
            leftMax[0] = heights[0];
            rightMax[heights.Length - 1] = heights[heights.Length - 1];
            for(var i = 1; i < heights.Length; i++)
            {
                leftMax[i] = Math.Max(leftMax[i -1], heights[i]);
            }
            for(var i = heights.Length - 2; i >= 0; i--)
            {
                rightMax[i] = Math.Max(rightMax[i+ 1], heights[i]);
            }

            var result = 0;
            for(var i = 1; i < heights.Length - 1; i++)
            {
                result += Math.Min(leftMax[i], rightMax[i]) - heights[i];
            }
            return result;
        }
    }
}
