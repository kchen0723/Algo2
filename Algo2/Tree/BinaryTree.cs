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

        public static int Min(BinaryTree<int> tree)
        {
            if (tree == null || tree.Root == null)
            {
                return int.MinValue;
            }

            return MinHelp(tree.Root);
        }

        private static int MinHelp(TreeNode<int> node)
        {
            var result = node.NodeValue;
            if (node.Left != null)
            { 
                var leftMin = MinHelp(node.Left);
                result = Math.Min(result, leftMin);
            }
            if (node.Right != null)
            { 
                var rightMin = MinHelp(node.Right);
                result = Math.Min(result, rightMin);
            }
            return result;
        }

        public static int Max(BinaryTree<int> tree)
        {
            if (tree == null || tree.Root == null)
            {
                return int.MinValue;
            }

            return MaxHelp(tree.Root);
        }

        private static int MaxHelp(TreeNode<int> node)
        {
            var result = node.NodeValue;
            if (node.Left != null)
            {
                var leftMin = MaxHelp(node.Left);
                result = Math.Max(result, leftMin);
            }
            if (node.Right != null)
            {
                var rightMin = MaxHelp(node.Right);
                result = Math.Max(result, rightMin);
            }
            return result;
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

        public void PreOrderIteration(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }
            var stack = new Stack<TreeNode<T>>();
            stack.Push(node);
            var result = new List<T>();
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                Console.WriteLine(current.NodeValue.ToString());
                result.Add(current.NodeValue);
                if (current.Right != null)
                {
                    stack.Push(current.Right);
                }
                if (current.Left != null)
                {
                    stack.Push(current.Left);
                }
            }
            Console.WriteLine(result.Count.ToString());
        }

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

        public void InOrderIteration(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }
            var stack = new Stack<TreeNode<T>>();
            stack.Push(node);
            var result = new Dictionary<TreeNode<T>, bool>();
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                while (current.Left != null && result.ContainsKey(current.Left) == false)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                Console.WriteLine(current.NodeValue.ToString());
                if (current.Right != null)
                { 
                    stack.Push(current.Right);
                }
                result.Add(current, true);
            }
            Console.WriteLine(result.Keys.Count.ToString());
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
