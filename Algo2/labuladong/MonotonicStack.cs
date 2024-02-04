using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.labuladong
{
    public class MonotonicStack
    {
        public static List<int> GetNextGreaterNumbers(List<int> numbers)
        {
            var result = new int[numbers.Count];
            var stack = new Stack<int>();
            for(var i = numbers.Count - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && stack.Peek() <= numbers[i])
                { 
                    stack.Pop();
                }
                result[i] = (stack.Count == 0 ? -1 : stack.Peek());
                stack.Push(numbers[i]);
            }
            return result.ToList();
        }
    }
}
