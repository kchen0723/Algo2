using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Tree
{
    public class BinaryTree<T> where T : IComparable
    {
        public TreeNode<T> Root { get; set; }

        public BinaryTree() 
        {
        }
        public BinaryTree(T data)
        { 
            Root = new TreeNode<T>() { NodeValue = data };    
        }

        public void PreOrder(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }
            Console.WriteLine(node.NodeValue.ToString());
            PreOrder(node.Left); 
            PreOrder(node.Right);
        }

        //Todo: how to do it by Iteration?
        public void InOrder(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }
            InOrder(node.Left);
            Console.WriteLine(node.NodeValue.ToString());
            InOrder(node.Right);
        }

        public void PostOrder(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }
            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.WriteLine(node.NodeValue.ToString());
        }

        public void LevelOrder(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(node);
            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                Console.WriteLine(current.NodeValue.ToString());

                if (current.Left != null)
                { 
                    queue.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }
        }

        public TreeNode<T> GetLowestCommonAncestorByDp(T n1, T n2)
        {
            return GetLowestCommonAncestorByDpHelp(Root, n1, n2);
        }

        private TreeNode<T> GetLowestCommonAncestorByDpHelp(TreeNode<T> current, T n1, T n2)
        {
            if (current == null)
            {
                return null;
            }
            if (current.NodeValue.CompareTo(n1) == 0)
            {
                return current;
            }
            if (current.NodeValue.CompareTo(n2) == 0)
            {
                return current;
            }

            var left = GetLowestCommonAncestorByDpHelp(current.Left, n1, n2);
            var right = GetLowestCommonAncestorByDpHelp(current.Right, n1, n2);
            if (left != null && right != null)
            {
                return current;
            }
            if (left != null)
            {
                return left;
            }
            if (right != null)
            {
                return right;
            }

            return null;
        }
    }
}
