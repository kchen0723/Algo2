using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Pramp
{
    public class ShortestCellPath
    {
        //BFS
        public static int GetShortestPathByBfs(int[,] arr, int sourceRow, int sourceCol, int targetRow, int targetCol)
        {
            int result = -1;
            var visited = new bool[arr.GetLength(0), arr.GetLength(1)];
            Queue<List<Tuple<int, int>>> q = new Queue<List<Tuple<int, int>>>();
            q.Enqueue(new List<Tuple<int, int>>() { new Tuple<int, int>(sourceRow, sourceCol) });
            var isFound = false;
            while (q.Count > 0)
            {
                var currentLevel = q.Dequeue();
                result++;
                List<Tuple<int, int>> nextLevel = new List<Tuple<int, int>>();
                foreach( var item in currentLevel )
                {
                    if(item.Item1 == targetRow && item.Item2 == targetCol )
                    {
                        isFound = true;
                        break;
                    }

                    GetShortestPathHelper(arr, nextLevel, visited, item.Item1, item.Item2 + 1);  //right
                    GetShortestPathHelper(arr, nextLevel, visited, item.Item1, item.Item2 - 1);  //left
                    GetShortestPathHelper(arr, nextLevel, visited, item.Item1 + 1, item.Item2);  //down
                    GetShortestPathHelper(arr, nextLevel, visited, item.Item1 - 1, item.Item2);  //up
                }
                q.Enqueue(nextLevel);
                if (isFound)
                {
                    break;
                }
            }
            return result;
        }

        private static void GetShortestPathHelper(int[,] arr, List<Tuple<int, int>> nextLevl, bool[,] visited, int row, int col)
        { 
            if(row >= 0 && col >= 0 && row < arr.GetLength(0) && col < arr.GetLength(1))
            {
                if (visited[row, col] == false && arr[row, col] == 1)
                {
                    visited[row, col] = true;
                    nextLevl.Add(new Tuple<int, int>(row, col));
                }
            }
        }
    }
}
