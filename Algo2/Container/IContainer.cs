using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Container
{
    public interface IContainer<T>
    {
        int Count { get; }
        bool IsEmpty { get; }
        bool IsFull { get; }
        void Insert(T item);
        void Delete(T item);
    }
}
