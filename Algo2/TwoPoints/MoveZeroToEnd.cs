using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.TwoPoints
{
    public class MoveZeroToEnd
    {
        public static void Move(int[] arr)
        {
            var index = 0;
            foreach (var item in arr)
            {
                if (item != 0)
                {
                    arr[index] = item;
                    index++;
                }
            }
            for (var j = index; j < arr.Length; j++)
            {
                arr[j] = 0;
            }
        }
    }
}
