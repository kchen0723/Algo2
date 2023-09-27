using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DP
{
    //return an array of a array produce except the item itself
    public class ArrayProductExceptItemItself
    {
        public static List<int> GetArrayProductExceptItemItself(int[] arr)
        {
            var result = new List<int>();
            if (arr == null || arr.Length < 2)
            {
                return result;
            }

            result.Add(arr[1]);
            result.Add(arr[0]);
            for (var i = 2; i < arr.Length; i++)
            {
                var last = result[result.Count - 1];
                for (var j = 0; j < result.Count; j++)
                {
                    result[j] *= arr[i];
                }
                result.Add(last * arr[i - 1]);
            }
            return result;
        }
    }
}
