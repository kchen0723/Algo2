using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Utility
{
    public class ArrayHelper
    {
        public static List<int> CreateUniquueSortedList(int min, int max, int count = 10)
        {
            var result = CreateUniqueList(min, max, count);
            result.Sort();
            return result;
        }

        public static List<int> CreateUniqueList(int min, int max, int count = 10)
        {
            var result = CreateList(min, max, count);
            return result.Distinct().ToList();
        }

        public static List<int> CreateSortedList(int min, int max, int count = 10)
        {
            var result = CreateList(min, max, count);
            result.Sort();
            return result;
        }

        public static List<int> CreateList(int min, int max, int count = 10)
        {
            var result = new List<int>();
            Random r = new Random();
            for (var i = 0; i < count; i++)
            {
                result.Add(r.Next(min, max));
            }
            return result;
        }
    }
}
