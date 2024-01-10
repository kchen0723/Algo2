using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.CombinationAndPermutation
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
            GetPermutationFromUniqueArrayBackTracking(nums, length, selected, candidate, result);
            return result;
        }

        private static void GetPermutationFromUniqueArrayBackTracking(int[] nums, int length, bool[] selected, List<int> candidate, List<List<int>> result) 
        {
            if (candidate.Count == length)  //base case
            { 
                result.Add(candidate.ToArray().ToList());
                return;
            }

            for(var i = 0; i < nums.Length; i++) 
            {
                if (selected[i]) 
                {
                    continue;
                }

                selected[i] = true;
                candidate.Add(nums[i]);
                GetPermutationFromUniqueArrayBackTracking(nums, length, selected, candidate, result);
                candidate.RemoveAt(candidate.Count - 1);
                selected[i] = false;
            }
        }

        public static List<List<int>> GetPermutationFromDuplicateArray(int[] nums, int length)
        {
            var result = new List<List<int>>();
            if (nums == null || nums.Length == 0 || length == 0 || length > nums.Length)
            {
                return result;
            }

            Array.Sort(nums);
            var selected = new bool[nums.Length];
            var candidate = new List<int>();
            GetPermutationFromDuplicateArrayBackTracking(nums, length, selected, candidate, result);
            return result;
        }

        private static void GetPermutationFromDuplicateArrayBackTracking(int[] nums, int length, bool[] selected, List<int> candidate, List<List<int>> result)
        {
            if (candidate.Count == length)  //base case
            {
                result.Add(candidate.ToArray().ToList());
                return;
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (selected[i])
                {
                    continue;
                }
                if(i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                selected[i] = true;
                candidate.Add(nums[i]);
                GetPermutationFromDuplicateArrayBackTracking(nums, length, selected, candidate, result);
                candidate.RemoveAt(candidate.Count - 1);
                selected[i] = false;
            }
        }

        public static List<List<int>> GetPermutationMultipleTimes(int[] nums, int length)
        {
            var result = new List<List<int>>();
            if (nums == null || nums.Length == 0 || length == 0)
            {
                return result;
            }

            var candidate = new List<int>();
            GetPermutationMultipleTimesBackTracking(nums, length, candidate, result);
            return result;
        }

        private static void GetPermutationMultipleTimesBackTracking(int[] nums, int length, List<int> candidate, List<List<int>> result)
        {
            if (candidate.Count == length)  //base case
            {
                result.Add(candidate.ToArray().ToList());
                return;
            }

            for (var i = 0; i < nums.Length; i++)
            {
                candidate.Add(nums[i]);
                GetPermutationMultipleTimesBackTracking(nums, length, candidate, result);
                candidate.RemoveAt(candidate.Count - 1);
            }
        }

        public static List<List<T>> GetPermutationMultipleTimesSubset<T>(T[] nums, int length)
        {
            var result = new List<List<T>>();
            if (nums == null || nums.Length == 0 || length == 0)
            {
                return result;
            }

            var candidate = new List<T>();
            GetPermutationMultipleTimesSubsetBackTracking(nums, length, candidate, result);
            return result;
        }

        private static void GetPermutationMultipleTimesSubsetBackTracking<T>(T[] nums, int length, List<T> candidate, List<List<T>> result)
        {
            result.Add(candidate.ToArray().ToList());
            if (candidate.Count >= length)  //base case
            {
                return;
            }

            for (var i = 0; i < nums.Length; i++)
            {
                candidate.Add(nums[i]);
                GetPermutationMultipleTimesSubsetBackTracking(nums, length, candidate, result);
                candidate.RemoveAt(candidate.Count - 1);
            }
        }
    }
}
