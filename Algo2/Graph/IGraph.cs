using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Graph
{
    public interface IGraph<T>
    {
        int GetNumberOfVertex();
        int GetNumberOfEdge();
    }
}
