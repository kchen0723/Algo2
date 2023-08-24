﻿using Algo2.TwentyfourGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Tree
{
    public class CalculateTree
    {
        public static string Serialize<T>(TreeNode<T> root)
        {
            var result = string.Empty;
            if(root == null)
            {
                return result;
            }

            result = SerializeHelp(root);
            return result;
        }

        private static string SerializeHelp<T>(TreeNode<T> root)
        {
            var result = new StringBuilder();
            if (root == null)
            {
                return result.ToString();
            }

            var left = SerializeHelp<T>(root.Left);
            var right = SerializeHelp<T>(root.Right);
            var shouldLeftAddBracket = ShouldAddBracket(root, root.Left);
            var shouldRightAddBracket = ShouldAddBracket(root, root.Right);

            if (shouldLeftAddBracket)
            {
                result.Append("(");
                result.Append(left);
                result.Append(")");
            }
            else
            {
                result.Append(left);
            }
            result.Append(root.NodeValue.ToString());
            if (shouldRightAddBracket)
            {
                result.Append("(");
                result.Append(right);
                result.Append(")");
            }
            else
            {
                result.Append(right);
            }
            return result.ToString();
        }

        private static bool ShouldAddBracket<T>(TreeNode<T> left, TreeNode<T> right)
        {
            if(left != null && right != null)
            {
                if (left.NodeValue.ToString() == "*" || left.NodeValue.ToString() == "/")
                {
                    if (right.NodeValue.ToString() == "+" || right.NodeValue.ToString() == "-")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static TreeNode<string> Deserialize<T>(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            var tokens = Calculate.GetTokens(str);
            var postfix = Calculate.ParseToPostfixExpression(tokens);
            var stack = new Stack<TreeNode<string>>();
            foreach(var token in postfix)
            {
                if(Calculate.IsNumber(token))
                {
                    var node = new TreeNode<string>() {NodeValue = token};
                    stack.Push(node);
                }
                else
                {
                    var right = stack.Pop();
                    var left = stack.Pop();
                    var node = new TreeNode<string>() { NodeValue = token, Left = left, Right = right};
                    stack.Push(node);
                }
            }
            return stack.Pop();
        }
    }
}
