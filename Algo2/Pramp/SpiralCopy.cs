using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Pramp
{
    public class SpiralCopy
    {
        public static int[] ProcessSpiralCopy(int[,] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return new int[] { };
            }

            var top = 0;
            var bottom = arr.GetLength(0);   //the getlength(0) means row count
            var left = 0;
            var right = arr.GetLength(1);    //the getlength(0) means column count
            var result = new List<int>();
            while(true)
            {
                for(var i = left; i < right; i++)
                {
                    result.Add(arr[top, i]);
                }
                for (var i = top + 1; i < bottom; i++)
                { 
                    result.Add(arr[i, right - 1]);
                }
                if (top >= bottom - 1)
                {
                    break;
                }

                for (var i = right - 2; i >= left; i--)
                {
                    result.Add(arr[bottom - 1, i]);
                }
                for (var i = bottom - 2; i >= top + 1; i--)
                {
                    result.Add(arr[i, left]);
                }

                top++;
                bottom--;
                left++;
                right--;
            }
            return result.ToArray();
        }
    }
}
