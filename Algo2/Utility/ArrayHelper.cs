using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Utility
{
    public class ArrayHelper
    {
        public static List<int> CreateUniquueSortedArray(int start, int end, int step = 1)
        {
            var result = new List<int>();
            for (var i = start; i <= end; i += step)
            {
                result.Add(i);
            }
            return result;
        }
    }
}
