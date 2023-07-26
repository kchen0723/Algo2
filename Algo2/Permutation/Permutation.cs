using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Permutation
{
    public class Permutation
    {
        public static List<List<int>> GetPermutationFromUniqueArray(int[] nums, int length)
        { 
            var result = new List<List<int>>();
            if (nums == null || nums.Length == 0 || length == 0 || length > nums.Length)
            {
                return result;   
            }

            var selected = new bool[nums.Length];
            var candidate = new List<int>();
            GetPermutationFromUniqueArrayHelp(nums, length, selected, candidate, result);
            return result;
        }

        private static void GetPermutationFromUniqueArrayHelp(int[] nums, int length, bool[] selected, List<int> candidte, List<List<int>> result) 
        {
            if (candidte.Count == length)  //base case
            { 
                result.Add(candidte.ToArray().ToList());
            }

            for(var i = 0; i < nums.Length; i++) 
            {
                if (selected[i]) 
                {
                    continue;
                }

                selected[i] = true;
                candidte.Add(nums[i]);
                GetPermutationFromUniqueArrayHelp(nums, length, selected, candidte, result);
                candidte.RemoveAt(candidte.Count - 1);
                selected[i] = false;
            }
        }
    }
}
