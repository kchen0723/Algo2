using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.labuladong
{
    public class HouseRobber
    {
        public static int GetMaxValueWithoutAdjacentDp(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return 0;
            }

            var dp = new int[arr.Length + 1];
            return dp[arr.Length];
        }

        public static int GetMaxValueWithoutAdjacentBackTracking(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            { 
                return 0;
            }

            var selected = new bool[arr.Length];
            var result = 0;
            GetMaxValueWithoutAdjacentBackTrackingHelp(arr, selected, 0, ref result);
            return result;
        }

        private static void GetMaxValueWithoutAdjacentBackTrackingHelp(int[] arr, bool[] selected, int index, ref int result)
        {
            var candidate = 0;
            for(var i = 0; i < selected.Length; i++)
            {
                if (selected[i])
                {
                    candidate += arr[i];
                }
            }
            result = Math.Max(result, candidate);

            for(var i = index; i < arr.Length; i++)
            {
                if(i == 0 || selected[i - 1] == false) 
                {
                    selected[i] = true;
                    GetMaxValueWithoutAdjacentBackTrackingHelp(arr, selected, i + 1, ref result);
                    selected[i] = false;
                }
                
            }
        }
    }
}
