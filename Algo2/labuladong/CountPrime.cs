using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.labuladong
{
    public class CountPrime
    {
        public static int Count(int number)
        {
            if (number < 2)
            {
                return 0;
            }

            bool[] isPrimes = new bool[number + 1];
            for(var i = 0; i < isPrimes.Length; i++)
            {
                isPrimes[i] = true;
            }

            for (int i = 2; i * i <= number; i++)
            {
                if (isPrimes[i])
                {
                    for (int j = i * i; j <= number; j += i)  //i的倍数不是素数
                    {
                        isPrimes[j] = false;
                    }
                }
            }
            int result = 0;
            for (int i = 2; i <= number; i++)
            {
                if (isPrimes[i])
                { 
                    result++;
                }
            }
            return result;
        }
    }
}
