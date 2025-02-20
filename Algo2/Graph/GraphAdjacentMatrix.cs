using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Graph
{
    public class GraphAdjacentMatrix : IGraph
    {
        private float[,] _matrix;

        public GraphAdjacentMatrix(int size)
        { 
            _matrix = new float[size, size];
        }

        public void AddEdge(int vertex1, int vertex2, float weight = 1)
        {
            _matrix[vertex1, vertex2] = weight;
            _matrix[vertex2, vertex1] = weight;
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
            for (var i = 0; i < count; i++)
            {
                if (_matrix[vertexIndex, i] > 0)
                {
                    if (colours[i] == null)
                    {
                        if (IsBiPartiteByDfs(colours, i, !colour) == false)
                        {
                            return false;
                        }
                    }
                    else if (colours[i] == colour)
                    {
                        return false;
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
