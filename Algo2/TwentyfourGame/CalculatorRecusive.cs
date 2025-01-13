using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.TwentyfourGame
{
    public class CalculatorRecusive
    {
        public static float ToFloat(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0f;
            }
            
            var result = 0f;
            var denominator = 0f;
            foreach (var item in str)
            {
                if ((item >= '0' && item <= '9') || item == '.')
                {
                    if (item == '.')
                    {
                        denominator = 1f;
                    }
                    else
                    {
                        if (denominator == 0)
                        {
                            result = 10 * result + (item - '0');
                        }
                        else
                        {
                            denominator *= 10;
                            result += (item - '0') / denominator;
                        }
                    }   
                }
                else
                {
                    return 0f;
                }
            }
            return result;
        }

        public static float Calculate(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0f;
            }

            var expressList = new List<char>(str);
            return CalculateHelp(expressList);
        }

        public static float CalculateHelp(List<char> expressList)
        {
            Stack<float> stack = new Stack<float>();
            var tokens = new List<char>();
            var num = 0f;
            var sign = '+';
            while(expressList.Count > 0)
            {
                var token = expressList[0];
                expressList.RemoveAt(0);
                if ((token >= '0' && token <= '9') || token == '.')
                {
                    tokens.Add(token);
                }
                if(token == '(' || token == ')' || token == '+' || token == '-' || token == '*' || token == '/'
                    || expressList.Count == 0)
                {
                    if (tokens.Count > 0)
                    {
                        num = ToFloat(new string(tokens.ToArray()));
                        tokens.Clear();
                    }
                    if (token == '(')
                    { 
                        num = CalculateHelp(expressList);
                    }
                    switch (sign)
                    {
                        case '+':
                            stack.Push(num);
                            break;
                        case '-':
                            stack.Push(0 - num);
                            break;
                        case '*':
                            stack.Push(stack.Pop() * num);
                            break;
                        case '/':
                            stack.Push(stack.Pop() / num);
                            break;
                    }
                    if (token == ')')
                    {
                        break;
                    }
                    sign = token;
                }
            }
            return stack.Sum();
        }
    }
}
