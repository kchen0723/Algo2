using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.WindowsRuntime;
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

        public static void RecursiveArrayToIterative(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return;
            }

            Stack<int> s = new Stack<int>();
            s.Push(array[0]);
            var index = 1;
            while (s.Count > 0) 
            {
                var item = s.Pop();
                Console.WriteLine(item);
                if (index < array.Length)
                {
                    s.Push(array[index]);
                    index++;
                }
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

        public static void RecursiveLinkedToInterative(LinkedList<int> linkedList)
        {
            if (linkedList == null || linkedList.Count == 0)
            {
                return;
            }

            Stack<LinkedListNode<int>> s = new Stack<LinkedListNode<int>>();
            s.Push(linkedList.First);
            while (s.Count > 0)
            {
                var item = s.Pop();
                Console.WriteLine(item.Value);
                if (item.Next != null)
                {
                    s.Push(item.Next);
                }
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

            LinkedListNodeDS<T> newFirstNode = null;
            LinkedListNodeDS<T> newLastNode = null;
            ReverseHelp(linkedList.First, ref newFirstNode, ref newLastNode);
            LinkedListDS<T> result = new LinkedListDS<T>();
            result.Insert(newFirstNode);
            return result;
        }

        private static void ReverseHelp<T>(LinkedListNodeDS<T> currentNode, ref LinkedListNodeDS<T> newFirstNode, ref LinkedListNodeDS<T> newLastNode) where T : IComparable<T>
        {
            if (currentNode.Next == null) //last node
            {
                currentNode.Previous = null;
                newFirstNode = currentNode;
                newLastNode = currentNode;
                return;
            }

            ReverseHelp(currentNode.Next, ref newFirstNode, ref newLastNode);
            currentNode.Next = null;
            currentNode.Previous = null;
            newLastNode.Next = currentNode;
            currentNode.Previous = newLastNode;
            newLastNode = currentNode;
        }

        public static LinkedListDS<T> BetterReverse<T>(LinkedListDS<T> linkedList) where T : IComparable<T>
        {
            if (linkedList == null || linkedList.IsEmpty)
            {
                return linkedList;
            }
            
            var first = BetterReserveHelp(linkedList.First); 
            var result = new LinkedListDS<T>();
            result.Insert(first);
            return result;
        }

        private static LinkedListNodeDS<T> BetterReserveHelp<T>(LinkedListNodeDS<T> currentNode) where T : IComparable<T>
        {
            if (currentNode == null || currentNode.Next == null)
            {
                return currentNode;
            }

            var reversedNode = BetterReserveHelp(currentNode.Next);
            currentNode.Previous = currentNode.Next;
            currentNode.Next.Next = currentNode;
            currentNode.Next = null;
            
            return reversedNode;
        }

        public static int[] BestReverseArray(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return array;
            }
            var result = new int[array.Length];
            BestReverseArrayHelper(array, result, 0);
            return result;
        }

        private static void BestReverseArrayHelper(int[] array, int[] result, int index)
        {

            if (index < 0 || index >= array.Length)
            {
                return;
            }

            BestReverseArrayHelper(array, result, index + 1);
            result[array.Length - index - 1] = array[index];
        }

        public static LinkedListDS<T> BestReverseLinkedList<T>(LinkedListDS<T> linkedList) where T : IComparable<T>
        {
            if (linkedList == null || linkedList.IsEmpty)
            {
                return linkedList;
            }

            LinkedListDS<T> result = new LinkedListDS<T>();
            BestReverseLinkedListHelp(linkedList.First, result);
            return result;
        }

        private static void BestReverseLinkedListHelp<T>(LinkedListNodeDS<T> currentNode, LinkedListDS<T> result) where T : IComparable<T>
        {
            if (currentNode == null)
            {
                return;
            }

            BestReverseLinkedListHelp(currentNode.Next, result);
            result.InsertFirst(currentNode);
        }
    }
}
