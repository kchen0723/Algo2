using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.List
{
    public class SequenceList<T> : IListDS<T>
    {
        private readonly int _defaultSize = 10;
        private int _pointIndex = -1;
        private T[] _items;

        public SequenceList(int size) 
        { 
            _defaultSize = size;
            _items = new T[size];
        }

        public SequenceList()
        {
            _items = new T[_defaultSize];
        }

        public T this[int index] 
        {
            get
            {
                if (index >= 0 && index <= _pointIndex)
                { 
                    return _items[index];
                }
                return default(T);
            }
            set
            {
                if (index >= 0 && index <= _pointIndex)
                {
                    _items[index] = value;
                }
            }
        }

        public int Count
        {
            get
            {
                return _pointIndex + 1;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return _pointIndex == -1;
            }
        }

        public void Append(T item)
        {
            ExpandCapacity();
            if (_pointIndex < _items.Length - 1)
            {
                _pointIndex += 1;
                _items[_pointIndex] = item;
            }
        }

        public void Clear()
        {
            _pointIndex = -1;
        }

        public T Delete(int index)
        {
            var result = _items[index];
            for (var i = index; i <= _pointIndex; i++)
            {
                _items[index] = _items[index + 1];
            }
            return result;
        }

        public int Find(T item)
        {
            for (var i = 0; i < _pointIndex; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        private void ExpandCapacity()
        {
            if (_pointIndex >= _items.Length - 1)
            {
                var newItems = new T[_items.Length * 2];
                for (var i = 0; i < _items.Length; i++)
                {
                    newItems[i] = _items[i];
                }
                _items = newItems;
            }
        }

        public void Insert(int index, T item)
        {
            ExpandCapacity();
            if (_pointIndex < _items.Length - 1 && index >= 0 && index <= _pointIndex)
            {
                for (var i = _pointIndex + 1; i > index; i--)
                {
                    _items[i] = _items[i - 1];
                }
                _items[index] = item;
            }
        }
    }
}
