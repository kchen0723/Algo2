using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algo2.TwentyfourGame
{
    public class Calculate
    {
        public static float Calcualte(string str)
        { 
            var tokents = GetTokens(str);
            var postfix = ParseToPostfixExpression(tokents);
            var result = CalculatePostfixExpression(postfix);
            return result;
        }
        public static List<string> GetTokens(string src)
        {
            var result = new List<string>();
            if (string.IsNullOrEmpty(src))
            {
                return result;
            }

            var pattern = "[0-9]+[\\.0-9]*|[\\(\\)+\\-\\*/]";
            var mathResult = Regex.Matches(src, pattern);
            for (var i = 0; i < mathResult.Count; i++)
            { 
                var item = mathResult[i];
                result.Add(item.Value);
            }
            return result;
        }

        public static List<string>  ParseToPostfixExpression(List<string> tokens)
        {
            var result = new List<string>();
            var operatorStack = new Stack<string>();
            foreach(var token in tokens)
            {
                if (IsNumber(token))
                {
                    result.Add(token);
                }
                else if (token == "(")
                {
                    operatorStack.Push(token);
                }
                else if (token == ")")
                {
                    while (operatorStack.Count > 0)
                    {
                        var last = operatorStack.Pop();
                        if (last == "(")
                        {
                            break;
                        }
                        else
                        {
                            result.Add(last);
                        }
                    }
                }
                else 
                { 
                    while(operatorStack.Count > 0)
                    {
                        var last = operatorStack.Peek();
                        if (last == "(" || ((token == "*" || token == "/") && (last == "+" || last == "-")))
                        {
                            break;
                        }
                        result.Add(last);
                        operatorStack.Pop();
                    }
                    operatorStack.Push(token);
                }
            }
            result.AddRange(operatorStack.ToArray());
            return result;
        }

        public static bool IsNumber(string str)
        {
            if (str == "(" || str == ")" || str == "+" || str == "-" || str == "*" || str == "/")
            {
                return false;
            }
            return true;
        }

        public static float CalculatePostfixExpression(List<string> tokens)
        {
            Stack<float> stack = new Stack<float>();
            foreach (var token in tokens)
            {
                if (IsNumber(token))
                {
                    stack.Push(ToFloat(token));
                }
                else
                { 
                    var right = stack.Pop();
                    var left = stack.Pop();
                    var midResult = Calculate2Numbers(left, right, token);
                    stack.Push(midResult);
                }
            }
            return stack.Pop();
        }

        public static float ToFloat(string str)
        {
            var result = 0f;
            float.TryParse(str, out result);
            return result;
        }

        public static float Calculate2Numbers(float left, float right, string token)
        {
            var result = 0f;
            switch (token)
            {
                case "+":
                    result = left + right;
                    break;
                case "-":
                    result = left - right;
                    break;
                case "*":
                    result = left * right;
                    break;
                case "/":
                    if (right != 0)
                    {
                        result = left / right;
                    }
                    break;

            }
            return result;
        }
    }
}
