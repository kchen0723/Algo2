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
            while (operatorStack.Count > 0)
            { 
                result.Add(operatorStack.Pop());
            }
            return result;
        }

        private static bool IsNumber(string str)
        {
            if (str == "(" || str == ")" || str == "+" || str == "-" || str == "*" || str == "/")
            {
                return false;
            }
            return true;
        }
    }
}
