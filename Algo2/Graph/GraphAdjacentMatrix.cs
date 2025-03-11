using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Graph
{
    public class GraphAdjacentMatrix : IGraph
    {
        private double?[,] _matrix;

        public GraphAdjacentMatrix(int size) : this(size, size)
        { 
        }

        public GraphAdjacentMatrix(int width, int height)
        {
            _matrix = new double?[width, height];
        }

        public GraphAdjacentMatrix(double?[,] matrix)
        {
            _matrix = matrix;
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

        public double DijkstraAlgorithm()
        {
            var result = 0;
            var distance = new double?[_matrix.GetLength(0)];
            var isUsed = new bool[_matrix.GetLength(0)];
            isUsed[0] = true;

            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                distance[i] = _matrix[0, i];
            }

            for (int i = 1; i < _matrix.GetLength(0); i++)
            {
                int index = -1;
                double? min = double.MaxValue;
                for (int j = 0; j < _matrix.GetLength(0); j++)
                {
                    if (isUsed[j] == false && min > distance[j])
                    {
                        min = distance[j];
                        index = j;
                    }
                }

                if (index == -1)
                {
                    break;
                }
                isUsed[index] = true;

                for (int j = 0; j < _matrix.GetLength(0); j++)
                {
                    if (isUsed[j] == false)
                    {
                        var candidate = distance[j] + _matrix[index, j];
                        var left = candidate == null ? double.MaxValue : candidate.Value;
                        var right = _matrix[index, j] == null ? double.MaxValue : _matrix[index, j].GetValueOrDefault();
                        _matrix[index, j] = Math.Min(left, right);
                    }
                }
            }
            return result;
        }

        public double?[,] FloydAlgorithm()
        {
            var result = _matrix.Clone() as double?[,];
            for (int k = 1; k < result.GetLength(0); k++)
            {
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(0); j++)
                    {
                        double? candidate = null;
                        if (result[i, k] != null || result[k, j] != null)
                        {
                            candidate = result[i, k].GetValueOrDefault() + result[k, j].GetValueOrDefault();
                        }
                        if (result[i, j] != null || candidate != null)
                        {
                            var left = result[i, j] == null ? double.MaxValue : result[i, j].GetValueOrDefault();
                            var right = candidate == null ? double.MaxValue : candidate.GetValueOrDefault();
                            result[i, j] = Math.Min(left, right);
                        }
                    }
                }
            }
            return result;
        }

        public double FindShortestPathByBackTracking(int start, int end)
        {
            if (start < 0 || end < 0 || start >= _matrix.GetLength(0) || end >= _matrix.GetLength(1))
            {
                return -1;
            }

            var result = double.MaxValue;
            var isVisited = new bool[_matrix.GetLength(0), _matrix.GetLength(1)];
            var paths = new List<List<int>>();
            var currentPath = new List<int>() { start + 1};
            var currentPathWeight = new List<double>();

            FindShortestPathByBackTrackingHelp(start, end, currentPath, currentPathWeight, paths, isVisited, ref result);
            return result;
        }

        private void FindShortestPathByBackTrackingHelp(int currentNodeIndex, int end, List<int> currentPath, 
            List<double> currentPathWeight, List<List<int>> paths, bool[,] isVisited, ref double result)
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
                    var displayColumnIndex = columnIndex + 1;
                    if(currentPath.Contains(displayColumnIndex) == false)
                    {
                        isVisited[currentNodeIndex, columnIndex] = true;
                        currentPath.Add(displayColumnIndex);
                        currentPathWeight.Add(_matrix[currentNodeIndex, columnIndex].GetValueOrDefault());

                        FindShortestPathByBackTrackingHelp(columnIndex, end, currentPath, currentPathWeight, paths, isVisited, ref result);

                        isVisited[currentNodeIndex, columnIndex] = false;
                        currentPath.RemoveAt(currentPath.Count - 1);
                        currentPathWeight.RemoveAt(currentPathWeight.Count - 1);
                    }
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
