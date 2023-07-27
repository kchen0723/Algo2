using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.CombinationAndPermutation
{
    public class Combination
    {
        public static List<List<int>> GetCombinationFromUniqueArray(int[] nums, int length)
        {
            var result = new List<List<int>>();
            if (nums == null || nums.Length == 0 || length == 0 || length > nums.Length)
            {
                return result;
            }

            var candidate = new List<int>();
            GetCombinationFromUniqueArrayHelp(nums, length, 0, candidate, result);
            return result;
        }

        private static void GetCombinationFromUniqueArrayHelp(int[] nums, int length, int index, List<int> candidate, List<List<int>> result)
        {
            if (candidate.Count == length)
            { 
                result.Add(candidate.ToArray().ToList());
                return;
            }

            for(var i = index; i < nums.Length; i++)
            {
                candidate.Add(nums[i]);
                GetCombinationFromUniqueArrayHelp(nums, length, i + 1, candidate, result);
                candidate.RemoveAt(candidate.Count - 1);
            }
        }
    }
}
