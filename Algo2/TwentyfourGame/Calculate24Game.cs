using Algo2.CombinationAndPermutation;
using Algo2.DividAndConquer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.TwentyfourGame
{
    //https://blog.csdn.net/problc/article/details/7287138, total 1362 answers
    public class Calculate24Game
    {
        public const int TARGET_NUMBER = 24;
        public const float TARGET_EPSILON = 0.0001f;
        public static readonly int[] NUMBERS = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        public static readonly char[] OPERATORS = new char[] { '+', '-', '*', '/' };

        public static bool IsTarget(float number)
        {
            if(Math.Abs(number - TARGET_NUMBER) < TARGET_EPSILON)
            {
                return true;
            }
            return false;
        }

        public static List<FormulaEntity> GetFormulas()
        { 
            var result = new List<FormulaEntity>();
            var combinations = Combination.GetCombinationMultipleTimes(NUMBERS, 4);
            foreach (var item in combinations)
            {
                var formula = new FormulaEntity() { Numbers = item };
                formula.ProcessFormulas();
                if (formula.IsValid)
                {
                    result.Add(formula);
                }
            }
            return result;
        }
    }

    public class FormulaEntity
    {
        public List<int> Numbers { get; set; } = new List<int>();
        public bool IsValid { get; private set; }
        public List<string> ValidFormlas { get; private set; } = new List<string>();

        public bool ProcessFormulas()
        {
            var formulas = BuildFormulas();
            foreach(var formulaInfo  in formulas)
            {
                var formula = formulaInfo.Formula;
                var bracketValues = DifferentBracketsToCalculate.AddDifferentBracketsToCalculate(formula);
                foreach (var bracketValue in bracketValues)
                {
                    if (Calculate24Game.IsTarget(bracketValue.Item1))
                    {
                        IsValid = true;
                        ValidFormlas.Add(bracketValue.Item2);
                    }
                }
            }
            return false;
        }

        private List<FormulaInfo> BuildFormulas()
        { 
            var result = new List<FormulaInfo>();
            var numberPermutations = Permutation.GetPermutationFromUniqueArray(Numbers.ToArray(), 4);
            var operatorPermutations = GetPermutationMultipleTimes<char>(Calculate24Game.OPERATORS, 3);
            foreach (var nums in numberPermutations)
            {
                foreach (var ops in operatorPermutations)
                { 
                    var formulaInfo = new FormulaInfo();
                    formulaInfo.Numbers = nums;
                    formulaInfo.Operators = ops;
                    result.Add(formulaInfo);
                }
            }
            return result;
        }

        public List<List<T>> GetPermutationMultipleTimes<T>(T[] values, int length)
        { 
            var result = new List<List<T>>();
            if (values == null || values.Length == 0 || length == 0)
            {
                return result;
            }

            var candidate = new List<T>();
            GetPermutationMultipleTimesHelp(values, length, candidate, result);
            return result;
        }

        public void GetPermutationMultipleTimesHelp<T>(T[] values, int length, List<T> candidate, List<List<T>> result)
        {
            if (candidate.Count == length)  //base case
            { 
                result.Add(candidate.ToArray().ToList());
                return;
            }

            for(var i = 0; i < values.Length; i++)
            {
                candidate.Add(values[i]);
                GetPermutationMultipleTimesHelp(values, length, candidate, result);
                candidate.RemoveAt(candidate.Count - 1);
            }
        }
    }

    public class FormulaInfo
    { 
        public List<int> Numbers { get; set; } = new List<int>();
        public List<char> Operators { get; set; } = new List<char>();

        public string Formula
        {
            get
            { 
                var result = new StringBuilder();
                if(Numbers.Count == Operators.Count + 1 && Operators.Count > 0)
                {
                    for(var i = 0; i < Operators.Count; i++)
                    {
                        result.Append(Numbers[i]);
                        result.Append(Operators[i]);
                    }
                    result.Append(Numbers[Numbers.Count - 1]);
                }
                return result.ToString();
            }
        }
    }
}
