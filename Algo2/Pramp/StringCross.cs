using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Pramp
{
    public class StringCross
    {
        //dig -> dog -> dot -> lot -> bot  BFS
        public static int GetCrossNumber(string[] arr, string target)
        {
            if (target == null || arr == null || arr.Length == 0 || arr.Contains(target) == false)
            {
                return 0;
            }

            int result = int.MaxValue;
            var visited = new List<string>();
            GetCrossNumberHelp(arr, target, visited, 0, ref result);
            return result;
        }

        private static void GetCrossNumberHelp(string[] arr, string target, List<string> visited, int index, ref int result)
        {
            if (arr[index] == target)
            {
                result = Math.Min(visited.Count, result);
                return;
            }

            for(var i = 0; i < arr.Length; i++)
            {
                if (visited.Contains(arr[i]))
                {
                    continue;
                }
                if (CanTransfer(arr[index], arr[i]))
                {
                    visited.Add(arr[index]);
                    GetCrossNumberHelp(arr, target, visited, i, ref result);
                    visited.RemoveAt(visited.Count - 1);
                }
            }
        }

        //return true when only one character difference
        private static bool CanTransfer(string source, string target)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(target) || source.Length != target.Length)
            {
                return false;
            }

            var diff = 0;
            for(var i = 0; i < source.Length && diff <= 2; i++)
            {
                if (source[i] != target[i])
                { 
                    diff++;
                }
            }

            return diff == 1;
        }
    }
}
