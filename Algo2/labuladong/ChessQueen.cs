using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.labuladong
{
    public class ChessQueen
    {
        private const int MaxQueen = 10;
        public static List<int[,]> SolveNQueen(int n)
        {
            var result = new List<int[,]>();
            if (n < 1 || n > MaxQueen)
            {
                return result;
            }

            var candidate = new int[n, n];
            SolveNQueenHelp(result, candidate, 0);
            return result;
        }

        private static void SolveNQueenHelp(List<int[,]> result, int[,] candidate, int row)
        {
            if (row == candidate.GetLength(0))
            { 
                result.Add(ArrayDeepCopy(candidate));
                return;
            }
            for (var col = 0; col < candidate.GetLength(0); col++)
            {
                if (IsCandidateValidate(candidate, row, col) == false)
                {
                    continue;
                }
                candidate[row, col] = 1;
                SolveNQueenHelp(result, candidate, row + 1);
                candidate[row, col] = 0;
            }
        }

        private static int[,] ArrayDeepCopy(int[,] array)
        {
            var result = new int[array.GetLength(0), array.GetLength(1)];
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    result[i, j] = array[i, j];
                }
            }
            return result;
        }

        private static bool IsCandidateValidate(int[,] candidate, int row, int col)
        {
            //need not check row
            //check col
            var n = candidate.GetLength(0);
            for(var i = 0; i < n; i++)
            {
                if (candidate[i, col] == 1)
                {
                    return false;
                }
            }
            //检查右上方
            for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++)
            {
                if (candidate[i, j] == 1)
                { 
                    return false; 
                }
            }
            //检查左上方
            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (candidate[i, j] == 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
