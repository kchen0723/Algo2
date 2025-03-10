using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Graph
{
    public class GraphAdjacentMatrix : IGraph
    {
        private float?[,] _matrix;

        public GraphAdjacentMatrix(int size) : this(size, size)
        { 
        }

        public GraphAdjacentMatrix(int width, int height)
        {
            _matrix = new float?[width, height];
        }

        public void AddEdge(int vertex1, int vertex2)
        {
            AddEdge(vertex1, vertex2, 1, true);
        }

        public void AddEdge(int vertex1, int vertex2, float weight, bool isSymmetry = false)
        {
            _matrix[vertex1, vertex2] = weight;
            if (isSymmetry)
            {
                _matrix[vertex2, vertex1] = weight;
            }
        }

        public float FindShortestPathByBackTracking(int start, int end)
        {
            if (start < 0 || end < 0 || start >= _matrix.GetLength(0) || end >= _matrix.GetLength(1))
            {
                return -1;
            }

            var result = float.MaxValue;
            var isVisited = new bool[_matrix.GetLength(0), _matrix.GetLength(1)];
            var paths = new List<List<int>>();
            var currentPath = new List<int>() { start + 1};
            var currentPathWeight = new List<float>();

            FindShortestPathByBackTrackingHelp(start, end, currentPath, currentPathWeight, paths, isVisited, ref result);
            return result;
        }

        private void FindShortestPathByBackTrackingHelp(int currentNodeIndex, int end, List<int> currentPath, 
            List<float> currentPathWeight, List<List<int>> paths, bool[,] isVisited, ref float result)
        {
            if (currentNodeIndex == end)
            {
                paths.Add(currentPath.ToArray().ToList());
                result = Math.Min(result, currentPathWeight.Sum());
                return;
            }

            for(var columnIndex = 0; columnIndex < _matrix.GetLength(1); columnIndex++)
            {
                if (isVisited[currentNodeIndex, columnIndex] == false && _matrix[currentNodeIndex, columnIndex] != null)
                {
                    isVisited[currentNodeIndex, columnIndex] = true;
                    currentPath.Add(columnIndex + 1);
                    currentPathWeight.Add(_matrix[currentNodeIndex, columnIndex].GetValueOrDefault());

                    FindShortestPathByBackTrackingHelp(columnIndex, end, currentPath, currentPathWeight, paths, isVisited, ref result);

                    isVisited[currentNodeIndex, columnIndex] = false;
                    currentPath.RemoveAt(currentPath.Count - 1);
                    currentPathWeight.RemoveAt(currentPathWeight.Count - 1);
                }
            }
        }

        public bool IsBiPartite()
        {
            var count = _matrix.GetLength(0);
            var colours = new bool?[count];  //null: not set;true: red colour; false: black colour
            for(var i = 0; i < count; i++)
            {
                if (colours[i] == null)
                {
                    if (IsBiPartiteByDfs(colours, i, true) == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool IsBiPartiteByDfs(bool?[] colours, int vertexIndex, bool colour)
        {
            colours[vertexIndex] = colour;
            var count = _matrix.GetLength(0);
            for (var neighbour = 0; neighbour < count; neighbour++)
            {
                if (_matrix[vertexIndex, neighbour].GetValueOrDefault() > 0)
                {
                    if (colours[neighbour] == null)
                    {
                        if (IsBiPartiteByDfs(colours, neighbour, !colour) == false)
                        {
                            return false;
                        }
                    }
                    else if (colours[neighbour] == colour)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsBiPartiteBfs()
        {
            var count = _matrix.GetLength(0);
            var colours = new bool?[count];  //null: not set;true: red colour; false: black colour
            for (var i = 0; i < count; i++)
            {
                if (colours[i] == null)
                {
                    if (IsBiPartiteByDfs(colours, i, true) == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsBiPartiteBfsHelper(int start, bool?[] colours) 
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            colours[start] = true;
            var count = _matrix.GetLength(0);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                for (var neighbour = 0; neighbour < count; neighbour++)
                {
                    if (_matrix[node, neighbour].GetValueOrDefault() > 0)
                    {
                        if (colours[neighbour] == null)
                        {
                            colours[neighbour] = !colours[node];
                            queue.Enqueue(neighbour);
                        }
                        else if (colours[neighbour] == colours[node])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public int GetNumberOfEdge()
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfVertex()
        {
            throw new NotImplementedException();
        }
    }
}
