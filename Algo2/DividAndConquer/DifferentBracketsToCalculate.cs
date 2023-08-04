using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DividAndConquer
{
    public class DifferentBracketsToCalculate
    {
        public static List<Tuple<float, string>> AddDifferentBracketsToCalculate(string str)
        { 
            var result = new List<Tuple<float, string>>();
            if (string.IsNullOrEmpty(str))
            {
                return result;
            }
            return AddDifferentBracketsToCalculateHelp(str);
        }

        public static List<Tuple<float, string>> AddDifferentBracketsToCalculateHelp(string str)
        { 
            var result = new List<Tuple<float, string>>();

            for(var i = 0; i < str.Length; i++) 
            {
                var item = str[i];
                if (item == '+' || item == '-' || item == '*' || item == '/')
                {
                    var leftString = str.Substring(0, i);
                    var rightString = str.Substring(i + 1, str.Length - i - 1);
                    var leftResult = AddDifferentBracketsToCalculateHelp(leftString);
                    var rightResult = AddDifferentBracketsToCalculateHelp(rightString);

                    foreach (var left in leftResult)
                    {
                        foreach (var right in rightResult)
                        {
                            var formula = $"({left.Item2}{item}{right.Item2})";
                            switch (item) 
                            {
                                case '+':
                                    result.Add(new Tuple<float, string>(left.Item1 + right.Item1, formula));
                                    break;
                                case '-':
                                    result.Add(new Tuple<float, string>(left.Item1 - right.Item1, formula));
                                    break;
                                case '*':
                                    result.Add(new Tuple<float, string>(left.Item1 * right.Item1, formula));
                                    break;
                                case '/':
                                    if (right.Item1 != 0)
                                    {
                                        result.Add(new Tuple<float, string>(left.Item1 / right.Item1, formula));
                                    }
                                    break;
                            }
                        }
                    }
                }
            }

            if (result.Count == 0)
            {
                float floatValue;
                float.TryParse(str, out floatValue);
                result.Add(new Tuple<float, string>(floatValue, str));
            }
            return result;
        }
    }
}
