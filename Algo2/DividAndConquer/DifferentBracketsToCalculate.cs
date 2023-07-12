using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DividAndConquer
{
    public class DifferentBracketsToCalculate
    {
        public static List<float> AddDifferentBracketsToCalculate(string str)
        { 
            var result = new List<float>();
            if(string.IsNullOrEmpty(str)) 
            { 
                return result; 
            }

            for(var i = 0; i < str.Length; i++) 
            {
                var item = str[i];
                if (item == '+' || item == '-' || item == '*' || item == '/')
                {
                    var leftString = str.Substring(0, i);
                    var rightString = str.Substring(i + 1, str.Length - i - 1);
                    var leftResult = AddDifferentBracketsToCalculate(leftString);
                    var rightResult = AddDifferentBracketsToCalculate(rightString);

                    foreach (var left in leftResult)
                    {
                        foreach (var right in rightResult)
                        { 
                            switch (item) 
                            {
                                case '+':
                                    result.Add(left + right);
                                    break;
                                case '-':
                                    result.Add(left - right);
                                    break;
                                case '*':
                                    result.Add(left * right);
                                    break;
                                case '/':
                                    if (right != 0)
                                    {
                                        result.Add(left / right);
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
                result.Add(floatValue);
            }
            return result;
        }
    }
}
