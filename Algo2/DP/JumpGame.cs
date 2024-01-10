using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DP
{
    public class JumpGame
    {
        //each num means the max step can jump for this index.
        //for example, [3, 2, 1, 0, 4], the 2 means max 2 steps can jump from here.
        //return true if can jump to the last number, otherwise, return false.
        public static bool CanJumpByDp(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            { 
                return false;
            }
            var dp = new bool[nums.Length];      //each item means whether can jump to the last element from here.
            dp[nums.Length - 1] = true;          //base case, set the last element to true as it already reach the last one.
            for(var i = nums.Length - 2; i >= 0; i--)   //from back to end
            {
                var maxStep = nums[i];
                for (var j = 1; j <= maxStep; j++)
                {
                    if (i + j < nums.Length)
                    {
                        if (dp[i + j])
                        {
                            dp[i] = true;      //transfor formula
                            break;
                        }
                    }
                }
            }
            return dp[0];
        }
    }
}
