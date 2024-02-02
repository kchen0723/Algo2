using System;
using System.Collections.Generic;
using System.Dynamic;
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

        public static bool IsValid(BinarySearchTree<int> tree)
        {
            if (tree == null || tree.Root == null)
            {
                return true;
            }

            var min = int.MaxValue;
            var max = int.MinValue;
            var result = IsValidHelp(tree.Root, ref min, ref max);
            return result;
        }

        private static bool IsValidHelp(TreeNode<int> node, ref int min, ref int max)
        {
            if (node.Left == null && node.Right == null)
            {
                min = node.NodeValue;
                max = node.NodeValue;
                return true;
            }

            var result = true;
            if (node.Left != null)
            {
                var leftMin = int.MaxValue;
                int leftMax = int.MinValue;
                var isLeftValid = IsValidHelp(node.Left, ref leftMin, ref leftMax);
                min = Math.Min(node.NodeValue, Math.Min(leftMin, leftMax));
                max = Math.Max(node.NodeValue, Math.Max(leftMin, leftMax)); 
                result = result && isLeftValid;
                if (node.NodeValue < leftMax)  //node value must be greater than all values of left sub tree. 
                {
                    result = false;
                }
            }
            if (node.Right != null)
            {
                var rightMin = int.MaxValue;
                int rightMax = int.MinValue;
                var isRightValid = IsValidHelp(node.Right, ref rightMin, ref rightMax);
                min = Math.Min(min, Math.Min(rightMin, rightMax));
                max = Math.Max(max, Math.Max(rightMin, rightMax));
                result = result && isRightValid;
                if (node.NodeValue > rightMin)  //node value must be smaller than all values of right sub tree
                {
                    result = false;
                }
            }
            return result;
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
