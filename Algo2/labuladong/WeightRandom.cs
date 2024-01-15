using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.labuladong
{
    public class WeightRandom
    {
        public static float GetRandomValue(float[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return -1;
            }
            if (arr.Length == 1)
            {
                return arr[0];
            }

            var sum = arr.Sum();
            var randomValue = new Random().Next(0, (int)Math.Ceiling(sum));
            var total = 0f;
            for (var i = 0; i < arr.Length; i++)
            {
                total += arr[i];
                if (total >= randomValue)
                {
                    return arr[i];
                }
            }

            return -1;
        }
    }
}
