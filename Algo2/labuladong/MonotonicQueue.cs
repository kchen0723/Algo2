using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.labuladong
{
    public class MonotonicQueue
    {
        private Queue<int> queue = new Queue<int>();

        public void Push(int value)
        { 
            while(queue.Count > 0 && queue.Peek() <= value)
            {
                queue.Dequeue();
            }
            queue.Enqueue(value);
        }

        public int Max()
        {
            if (queue.Count == 0)
            {
                return -1;
            }
            return queue.Peek();
        }

        public void Pop(int value)
        {
            if (queue.Count > 0 && queue.Peek() == value)
            {
                queue.Dequeue();
            }
        }
    }

    public class MaxSlidingWindow
    {
        public static List<int> GetMaxSliding(List<int> nums, int k)
        { 
            List<int> result = new List<int>();
            MonotonicQueue window = new MonotonicQueue();
            for(int i = 0; i < nums.Count; i++)
            {
                window.Push(nums[i]);
                if (i >= k - 1)
                {
                    result.Add(window.Max());
                    window.Pop(nums[i - k + 1]);
                }
            }
            return result;
        }
    }
}
