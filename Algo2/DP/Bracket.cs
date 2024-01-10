using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DP
{
    public class Bracket
    {
        public static bool IsValid(string brackets)
        {
            if (brackets == null || brackets.Length == 0)
            {
                return false;   
            }

            var stack = new Stack<char>();
            foreach ( char item in brackets )
            {
                if (item == '(')
                {
                    stack.Push(item);
                }
                else if (item == ')')
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }

        public static int GetLongestCountByDp(string brackets)
        {
            if (brackets == null || brackets.Length == 0)
            {
                return 0;
            }

            var dp = new int[brackets.Length + 1];  //each item means 
            /*
            0123456789
            ((())()()))))()()
            00024466810
             */
            var stack = new Stack<char>();
            for(var i = 1; i <= brackets.Length; i++)
            {
                var item = brackets[i - 1];
                if (item == '(')
                {
                    stack.Push(item);
                    dp[i] = dp[i - 1];
                }
                else if (item == ')')
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                        dp[i] = dp[i - 1] + 2;
                    }
                }
            }
            return dp.Max();
        }
    }
}
