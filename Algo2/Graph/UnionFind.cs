using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Graph
{
    public class UnionFind
    {
        private int _count;
        private int[] _parents;
        private int[] _size;

        public UnionFind() : this(10)
        { 
        }

        public UnionFind(int n)
        { 
            this._count = n;
            _parents = new int[n];
            _size = new int[n];
            for(var i = 0; i < n; i++)
            {
                _parents[i] = i;
                _size[i] = 1;
            }
        }
        //将树P和Q连接起来
        public void Union(int p, int q)
        {
            int rootP = FindRoot(p);
            int rootQ = FindRoot(q);
            if (rootP == rootQ)
            {
                return;
            }

            if (_size[rootP] > _size[rootQ])
            {
                _parents[rootQ] = rootP;
                _size[rootP] += _size[rootQ];
            }
            else
            {
                _parents[rootP] = rootQ;
                _size[rootQ] += _size[rootP];
            }
            _count--;
        }

        private int FindRoot(int x)
        {
            while (_parents[x] != x)
            {
                x = _parents[x];
            }
            return x;
        }

        private int FindRootAndReducePath(int x)
        {
            while (_parents[x] != x)
            {
                _parents[x] = _parents[_parents[x]];
                x = _parents[x];
            }
            return x;
        }

        public bool IsConnected(int p, int q)
        {
            int rootP = FindRoot(p);
            int rootQ = FindRoot(q);
            return rootP == rootQ;
        }

        public int Count()
        {
            return _count;
        }
    }
}
