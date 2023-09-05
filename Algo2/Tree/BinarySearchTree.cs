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

        public TreeNode<T> FindMaxNodeWhichIsSmallerThanTarget(T target)
        {
            if (Root == null)
            {
                return null;
            }

            TreeNode<T> result = null;
            var isEqueal = false;
            var current = Root;
            while (current != null)
            {
                var compareResult = current.NodeValue.CompareTo(target);
                if (compareResult < 0)
                {
                    result = current;
                    current = current.Right;
                }
                else if (compareResult == 0)
                {
                    current = current.Left;
                    isEqueal = true;
                    break;
                }
                else if (compareResult > 0)
                {
                    current = current.Left;
                }
            }
            if (isEqueal)
            {
                while (current != null && current.Right != null)
                {
                    current = current.Right;
                }
                result = current;
            }
            if (result != null && result.NodeValue.CompareTo(target) < 0)
            {
                return result;
            }
            return null;
        }

        public void Insert(T value)
        {
            TreeNode<T> newNode = new TreeNode<T>() { NodeValue = value };
            if(Root == null)
            {
                Root = newNode;
                return;
            }
            var current = Root;
            while (current != null)
            {
                var compareResult = current.NodeValue.CompareTo(value);
                if (compareResult < 0)
                {
                    if (current.Right == null)
                    {
                        current.Right = newNode;
                        return;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
                else if (compareResult == 0)
                {
                    return; //do nothing
                }
                else if (compareResult > 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = newNode;
                    }
                    else
                    {
                        current = current.Left;
                    }
                }
            }
        }
    }
}
