using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Algo2.Container;

namespace Algo2.IterationAndRecursive
{
    public class IterationAndRecursiveLearning
    {
        public static void IterationArray(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public static void RecursiveArray(int[] array)
        {
            RecursiveArrayHelp(array, 0);
        }

        public static void RecursiveArrayHelp(int[] array, int currentInex)
        {
            if (currentInex >= 0 && currentInex < array.Length)
            {
                Console.WriteLine(array[currentInex]);
                RecursiveArrayHelp(array, currentInex + 1);
            }
        }

        public static void IterationLinkedList(LinkedList<int> linkedList)
        {
            var current = linkedList.First;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }

        public static void RecursiveLinkedList(LinkedList<int> linkedList)
        {
            RecursiveLinkedListHelp(linkedList.First);
        }

        public static void RecursiveLinkedListHelp(LinkedListNode<int> current)
        {
            if (current != null)
            {
                Console.WriteLine(current.Value);
                RecursiveLinkedListHelp(current.Next);
            }
        }

        public static void RecursiveLinkedListDS(LinkedListDS<int> linkedList)
        {
            RecursiveLinkedListDSHelp(linkedList.First);
        }

        public static void RecursiveLinkedListDSHelp(LinkedListNodeDS<int> current)
        {
            if (current != null)
            {
                Console.WriteLine(current.Value);
                RecursiveLinkedListDSHelp(current.Next);
            }
        }

        public static LinkedListDS<T> Reverse<T>(LinkedListDS<T> linkedList) where T : IComparable<T>
        {
            if (linkedList.IsEmpty)
            {
                return linkedList;
            }

            LinkedListDS<T> result = new LinkedListDS<T>();
            var lastNode = ReverseHelp(linkedList.First, result);
            lastNode.Next = null;
            lastNode.Previous = null;
            result.Insert(lastNode);
            return result;
        }

        public static LinkedListNodeDS<T> ReverseHelp<T>(LinkedListNodeDS<T> currentNode, LinkedListDS<T> result) where T : IComparable<T>
        {
            if (currentNode.Next == null) //last node
            {
                return currentNode;
            }

            var reverseNode = ReverseHelp(currentNode.Next, result);
            reverseNode.Next = null;
            reverseNode.Previous = null;
            result.Insert(reverseNode);
            return currentNode;
        }
    }
}
