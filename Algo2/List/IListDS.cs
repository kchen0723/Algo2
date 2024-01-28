using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.List
{
    public interface IListDS<T>
    {
        int Count { get; }
        bool IsEmpty { get; }
        T this[int index] { get; set; }
        void Clear();
        void Append(T item);
        void InsertAfter(int index, T item);
        T Delete(int index);
        int Find(T item);
    }
}
