using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.TwentyfourGame
{
    public class Calculator2
    {
        private static readonly string PATTERN = "()+-*/";

        public static double Calculate(string input)
        {
            var tokens = GetTokens(input);
            return HandleBracketExpress(tokens);
        }

        //have bugs here, cannot handle nested bracket.
        public static double HandleBracketExpress(List<string> tokens)
        {
            double result = 0d;
            if (tokens == null || tokens.Count == 0)
            {
                return result;
            }

            Stack<List<string>> tokenStack = new Stack<List<string>> ();
            List<string> noBracketExpress = new List<string> ();
            foreach(var token in tokens)
            { 
                if (token == "(")
                {
                    tokenStack.Push(noBracketExpress.ToArray().ToList());
                    noBracketExpress.Clear();
                }
                else if (token == ")")
                {
                    var oneResult = HandleNoBracketExpress(noBracketExpress);
                    noBracketExpress.Clear();
                    noBracketExpress = tokenStack.Pop();
                    noBracketExpress.Add(oneResult.ToString());
                }
                else
                {
                    noBracketExpress.Add(token);
                }
            }
            result = HandleNoBracketExpress(noBracketExpress);
            return result;
        }

        public static double HandleNoBracketExpress(List<string> tokens)
        {
            double result = 0d;
            if (tokens == null || tokens.Count == 0)
            {
                return result;
            }

            List<string> onlyAddMinus = new List<string>();
            var index = 0;
            while (index < tokens.Count - 1)
            { 
                var nextToken = tokens[index + 1];
                if (nextToken != "*" && nextToken != "/")
                {
                    onlyAddMinus.Add(tokens[index]);
                    index++;
                }
                else
                {
                    var nextAddMinus = index;
                    while (nextAddMinus < tokens.Count)
                    {
                        if (tokens[nextAddMinus] == "+" || tokens[nextAddMinus] == "-")
                        {
                            break;
                        }
                        nextAddMinus++;
                    }
                    List<string> multipleDivides = new List<string>();
                    for (var k = index; k < nextAddMinus; k++)
                    {
                        multipleDivides.Add(tokens[k]);
                    }
                    var multipeDivideResult = HandleMultipleDivide(multipleDivides);
                    onlyAddMinus.Add(multipeDivideResult.ToString());
                    index = nextAddMinus;
                }
            }
            if (index == tokens.Count - 1)
            {
                onlyAddMinus.Add(tokens[index]);
            }
            result = HandleAddMinus(onlyAddMinus);
            return result;
        }

        public static double HandleMultipleDivide(List<string> tokens)
        {
            double result = 0d;
            if (tokens == null || tokens.Count == 0)
            {
                return result;
            }

            var aultipleOrDivide = string.Empty;
            foreach (var item in tokens)
            {
                if (item == "*" || item == "/")
                {
                    aultipleOrDivide = item;
                    continue;
                }

                var num = ToDouble(item);
                if (string.IsNullOrEmpty(aultipleOrDivide))
                {
                    result = num;
                }
                else if (aultipleOrDivide == "*")
                {
                    result *= num;
                }
                else if (aultipleOrDivide == "/")
                {
                    if (num != 0)
                    {
                        result /= num;
                    }
                    else
                    {
                        throw new ArgumentException("divide by zero");
                    }
                }
            }
            return result;
        }

        public static double HandleAddMinus(List<string> tokens)
        {
            double result = 0d;
            if (tokens == null || tokens.Count == 0)
            { 
                return result;
            }

            var addOrMinus = string.Empty;
            foreach (var item in tokens)
            {
                if (item == "+" || item == "-")
                { 
                    addOrMinus = item;
                    continue;
                }
                
                var num = ToDouble(item);
                if (string.IsNullOrEmpty(addOrMinus))
                {
                    result = num;
                }
                else if (addOrMinus == "+")
                {
                    result += num;
                }
                else if (addOrMinus == "-")
                { 
                    result -= num;
                }
            }
            return result;
        }

        public static double ToDouble(string str)
        {
            double result;
            double.TryParse(str, out result);
            return result;
        }

        public static List<string> GetTokens(string str)
        { 
            var result = new List<string>();
            if(string.IsNullOrEmpty(str) == false )
            {
                var startIndex = 0;
                for(var i = 0; i < str.Length; i++)
                {
                    var item = str[i];
                    if(PATTERN.Contains(item))
                    {
                        if(i > startIndex)
                        {
                            var token = str.Substring(startIndex, i - startIndex);
                            result.Add(token);
                        }
                        result.Add(item.ToString());
                        startIndex = i + 1;
                    }
                }
                if(startIndex < str.Length)
                {
                    var token = str.Substring(startIndex, str.Length - startIndex);
                    result.Add(token);
                }
            }
            return result;
        }
    }
}
