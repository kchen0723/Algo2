using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Pramp
{
    //Given a package with a weight limit limit and an array arr of item weights, implement a function getIndicesOfItemWeights 
    //that finds two items whose sum of weights equals the weight limit limit.Your function should return a pair[i, j] of the 
    //indices of the item weights, ordered such that i > j.If such a pair doesn’t exist, return an empty array.

    //Analyze the time and space complexities of your solution.
    //Example:
    //input:  arr = [4, 6, 10, 15, 16],  lim = 21
    //output: [3, 1] # since these are the indices of the
    //           # weights 6 and 15 whose sum equals to 21
    //Constraints:
    //    [time limit] 5000ms
    //    [input] array.integer arr
    //        0 ≤ arr.length ≤ 100
    //    [input] integer limit
    //    [output] array.integer
    public class IndexesOfItemsWeight
    {
        public static int[] GetIndicesOfItemWeights(int[] weights, int limit)
        {
            if (weights == null || weights.Length == 0 || limit <= 0 || limit > weights.Sum())
            {
                return new int[] { };
            }

            var weightIndexes = GetWeightIndexes(weights);
            foreach(var item in weights)
            {
                var candidate = limit - item;
                if (weightIndexes.ContainsKey(candidate))
                {
                    if (item == candidate)
                    {
                        if (weightIndexes[item].Count >= 2)
                        {
                            return new[] { weightIndexes[item][0], weightIndexes[item][1] };
                        }
                        continue;
                    }
                    else
                    {
                        return new[] { weightIndexes[item][0], weightIndexes[candidate][0] };
                    }
                }
            }
            return new int[] { };
        }

        private static Dictionary<int, List<int>> GetWeightIndexes(int[] weights)
        {
            Dictionary<int, List<int>> result = new Dictionary<int, List<int>>();
            for(var i = 0; i < weights.Length; i++)
            {
                if (result.ContainsKey(weights[i]))
                {
                    result[weights[i]].Add(i);
                }
                else
                {
                    result.Add(weights[i], new List<int> { i });
                }
            }
            return result;
        }
    }
}
