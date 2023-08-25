using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Container
{
    public class ContainerDS<T> : IContainer<T>
    {
        private readonly int _size;
        private int _containPointer;
        private T[] _items;

        public ContainerDS(int size)
        { 
            _size = size;
            _items = new T[size];
            _containPointer = -1;
        }

        public ContainerDS() : this(10) 
        {
        }

        public int Count
        {
            get 
            {
                return _containPointer + 1;
            }
        }

        public bool IsEmpty 
        {
            get
            { 
                return _containPointer == -1;
            }
        }

        public bool IsFull
        {
            get
            { 
                return (_containPointer == _size - 1);
            }
        }

        public void Delete(T item)
        {
            if (_containPointer >= 0)
            {
                for (var i = 0; i <= _containPointer; i++)
                { 
                    T current = _items[i];
                    if (current.Equals(item))
                    {
                        for (var j = i; j < _containPointer; j++)
                        {
                            _items[j] = _items[j + 1];
                        }
                        _containPointer -= 1;
                        break;
                    }
                }
            }
        }

        public void Insert(T item)
        {
            if (IsFull)
            {
                throw new ApplicationException("ContainerDS is full");
            }
            else
            { 
                _containPointer += 1;
                _items[_containPointer] = item;
            }
        }
    }
}
