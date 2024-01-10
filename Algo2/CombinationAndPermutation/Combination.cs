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
            GetCombinationFromUniqueArrayBackTracking(nums, length, 0, candidate, result);
            return result;
        }

        private static void GetCombinationFromUniqueArrayBackTracking(int[] nums, int length, int index, List<int> candidate, List<List<int>> result)
        {
            if (candidate.Count == length)
            { 
                result.Add(candidate.ToArray().ToList());
                return;
            }

            for(var i = index; i < nums.Length; i++)
            {
                candidate.Add(nums[i]);
                GetCombinationFromUniqueArrayBackTracking(nums, length, i + 1, candidate, result);
                candidate.RemoveAt(candidate.Count - 1);
            }
        }

        public static List<List<int>> GetCombinationFromDuplicateArray(int[] nums, int length)
        {
            var result = new List<List<int>>();
            if (nums == null || nums.Length == 0 || length == 0 || length > nums.Length)
            {
                return result;
            }

            var candidate = new List<int>();
            Array.Sort(nums);
            GetCombinationFromDuplicateArrayBackTracking(nums, length, 0, candidate, result);
            return result;
        }

        private static void GetCombinationFromDuplicateArrayBackTracking(int[] nums, int length, int index, List<int> candidate, List<List<int>> result)
        {
            if (candidate.Count == length)
            {
                result.Add(candidate.ToArray().ToList());
                return;
            }

            for (var i = index; i < nums.Length; i++)
            {
                if (i > index && nums[i] == nums[i - 1]) 
                {
                    continue;
                }
                candidate.Add(nums[i]);
                GetCombinationFromDuplicateArrayBackTracking(nums, length, i + 1, candidate, result);
                candidate.RemoveAt(candidate.Count - 1);
            }
            return;
        }

        public static List<List<int>> GetCombinationMultipleTimes(int[] nums, int length)
        {
            var result = new List<List<int>>();
            if (nums == null || nums.Length == 0 || length == 0)
            {
                return result;
            }

            var candidate = new List<int>();
            GetCombinationMultipleTimesBackTracking(nums, length, 0, candidate, result);
            return result;
        }

        private static void GetCombinationMultipleTimesBackTracking(int[] nums, int length, int index, List<int> candidate, List<List<int>> result)
        {
            if (candidate.Count == length)
            {
                result.Add(candidate.ToArray().ToList());
                return;
            }

            for (var i = index; i < nums.Length; i++)
            {
                candidate.Add(nums[i]);
                GetCombinationMultipleTimesBackTracking(nums, length, i, candidate, result);
                candidate.RemoveAt(candidate.Count - 1);
            }
        }

        public static List<List<int>> GetCombinationMultipleTimesSubset(int[] nums, int length)
        {
            var result = new List<List<int>>();
            if (nums == null || nums.Length == 0 || length == 0)
            {
                return result;
            }

            var candidate = new List<int>();
            GetCombinationMultipleTimesSubsetBackTracking(nums, length, 0, candidate, result);
            return result;
        }

        private static void GetCombinationMultipleTimesSubsetBackTracking(int[] nums, int length, int index, List<int> candidate, List<List<int>> result)
        {
            result.Add(candidate.ToArray().ToList());
            if (candidate.Count >= length)
            {
                return;
            }

            for (var i = index; i < nums.Length; i++)
            {
                candidate.Add(nums[i]);
                GetCombinationMultipleTimesSubsetBackTracking(nums, length, i, candidate, result);
                candidate.RemoveAt(candidate.Count - 1);
            }
        }
    }
}
