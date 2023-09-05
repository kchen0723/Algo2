using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Tree
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public TreeNode<T> Root { get; set; }

        public TreeNode<T> Find(T target)
        {
            if (Root == null)
            { 
                return null;
            }
            var current = Root;
            while (current != null)
            {
                var compareResult = current.NodeValue.CompareTo(target);
                if (compareResult == 0)
                {
                    return current;
                }
                else if (compareResult < 0)
                {
                    current = current.Right;
                }
                else if (compareResult > 0)
                {
                    current = current.Left;
                }
            }
            return null;
        }
    }
}
