using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Graph
{
    public class NumberOfIslands
    {
        public static int GetNumberOfIslands(int[,] binaryMatrix)
        {
            if (binaryMatrix == null || binaryMatrix.Length == 0)
            {
                return 0;
            }

            int rowCount = binaryMatrix.GetLength(0);
            int columnCount = binaryMatrix.GetLength(1);
            bool[,] isVisited = new bool[rowCount, columnCount];
            var result = 0;
            for(var i = 0; i < rowCount; i++)
            {
                for(var j = 0; j < columnCount; j++)
                {
                    if (isVisited[i, j] == false && binaryMatrix[i, j] == 1)
                    { 
                        result++;
                        GetNumberOfIslandsHelp(binaryMatrix, i, j, rowCount, columnCount, isVisited);
                    }
                }
            }
            return result;
        }

        private static void GetNumberOfIslandsHelp(int[,] binaryMatrix, int row, int col, int rowCount, int columnCount, bool[,] isVisited)
        {
            if (row < 0 || col < 0 || row >= rowCount || col >= columnCount)
            {
                return;
            }
            if (isVisited[row, col] == true || binaryMatrix[row, col] == 0)
            {
                return;
            }
            isVisited[row, col] = true;
            GetNumberOfIslandsHelp(binaryMatrix, row, col + 1, rowCount, columnCount, isVisited);
            GetNumberOfIslandsHelp(binaryMatrix, row, col - 1, rowCount, columnCount, isVisited);
            GetNumberOfIslandsHelp(binaryMatrix, row + 1, col, rowCount, columnCount, isVisited);
        }
    }
}
