using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public static float CalcuateByTokens(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0f;
            }

            var tokens = TwentyfourGame.Calculate.GetTokens(str);
            return CalculateByTokensHelp(tokens);
        }

        private static float CalculateByTokensHelp(List<string> tokens)
        {
            var num = 0f;
            var sign = "+";
            Stack<float> stack = new Stack<float>();
            var previousToken = string.Empty;
            while(tokens.Count > 0)
            {
                var token = tokens[0];
                tokens.RemoveAt(0);
                if (token == "(" || token == ")" || 
                    token == "+" || token == "-" || token == "*" || token == "/"
                    || tokens.Count == 0)
                {
                    if (token == "(")
                    {
                        num = CalculateByTokensHelp(tokens);
                    }
                    else if (tokens.Count == 0)
                    {
                        num = ToFloat(token);
                    }
                    else if(previousToken != string.Empty)
                    {
                        num = ToFloat(previousToken);
                    }
                    switch (sign)
                    {
                        case "+":
                            stack.Push(num);
                            break;
                        case "-":
                            stack.Push(0 - num);
                            break;
                        case "*":
                            stack.Push(stack.Pop() * num);
                            break;
                        case "/":
                            stack.Push(stack.Pop() / num);
                            break;
                    }
                    if (token == ")")
                    {
                        break;
                    }
                    sign = token;
                }
                else
                {
                    previousToken = token;
                }
            }
            return stack.Sum();
        }
    }
}
