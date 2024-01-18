using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.labuladong
{
    public class EggDrop
    {
        //有一栋100层的楼，和2个坚硬的鸡蛋，从楼上扔下鸡蛋，鸡蛋会在大于某一层刚好开始碎，那最少几次能测出鸡蛋能承受的最大楼层呢
        //https://blog.csdn.net/m0_60765523/article/details/122612992
        public static int GetMinTry(int eggCount, int floorCount)
        {
            if (eggCount <= 0 || floorCount <= 0)
            {
                return -1;
            }

            //if have enough eggs, then we can do it by binary search.
            if (eggCount >= Math.Log(floorCount, 2))
            { 
                return (int)Math.Ceiling(Math.Log(floorCount, 2));
            }

            //when eggCount < log(floorCount):
            //we can search section by section. we start from section 0. If broken in section[x], then try between section[x-1] and section[x]. Otherwise, move to next section.
            //Base case: if eggCount == 1, then you have to try from 0 to n floor. so the result = n.
            //if eggCount == 2,
            var dp = new int[eggCount + 1, floorCount + 1];  //each item means the mini try for (eggCount and floorCount).
            for(var i = 0; i < eggCount + 1; i++)
            {
                for (var j = 0; j < floorCount + 1; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if (i == 1)  //only have 1 egg
                    {
                        dp[1, j] = j;
                    }
                    else if (j == 1)   //only have 1 floor
                    {
                        dp[i, 1] = 1;
                    }
                    else if (i >= Math.Log(j, 2))
                    {
                        dp[i, j] = (int)Math.Ceiling(Math.Log(j, 2));
                    }
                    else
                    {
                        dp[i, j] = int.MaxValue;
                        for (var k = 1; k < j; k++)
                        {
                            var notBroken = dp[i, j - k];
                            var borken = dp[i - 1, k - 1];
                            var current = Math.Max(notBroken, borken) + 1;
                            dp[i, j] = Math.Min(dp[i, j], current);
                        }
                    }
                }
            }
            return dp[eggCount, floorCount];
        }

        //https://www.cnblogs.com/larry1024/p/17057913.html
        public static int GetMinDrop(int eggCount, int floorCount)
        {
            if (eggCount <= 0 || floorCount <= 0)
            {
                return -1;
            }

            //if have enough eggs, then we can do it by binary search.
            if (eggCount >= Math.Log(floorCount, 2))
            {
                return (int)Math.Ceiling(Math.Log(floorCount, 2));
            }

            var memory = new Dictionary<Tuple<int, int>, int>();
            return GetMinDropHelp(eggCount, floorCount, memory);
        }

        private static int GetMinDropHelp(int eggCount, int floorCount, Dictionary<Tuple<int, int>, int> memory)
        {
            var key = new Tuple<int, int>(eggCount, floorCount);
            if (memory.ContainsKey(key))
            {
                return memory[key];
            }

            if (eggCount == 0 || floorCount == 0)
            {
                memory[key] = 0;
                return 0;
            }
            if(eggCount == 1)
            {
                memory[key] = floorCount;
                return floorCount;
            }
            if (eggCount >= Math.Log(floorCount, 2))
            {
                memory[key] = (int)Math.Ceiling(Math.Log(floorCount, 2));
                return memory[key];
            }

            var result = int.MaxValue;
            for(var i = 1; i < floorCount + 1; i++)
            {
                var notBroken = GetMinDropHelp(eggCount, floorCount - i, memory);
                var broken = GetMinDropHelp(eggCount - 1, i - 1, memory);
                var currentFloor = Math.Max(notBroken, broken) + 1;
                result = Math.Min(result, currentFloor);
            }
            memory[key] = result;
            return result;
        }
    }
}
