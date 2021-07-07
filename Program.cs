using System;
using System.Collections.Generic;

namespace CycleDetection
{
    class Program
    {

        class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                }

                this.tail = node;
            }
        }

        static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep)
        {
            while (node != null)
            {
                Console.Write(node.data);

                node = node.next;

                if (node != null)
                {
                    Console.Write(sep);
                }
            }
        }
        static void Main(string[] args)
        {
            int tests = int.Parse(Console.ReadLine());
            for (int testsItr = 0; testsItr < tests; testsItr++)
            {
                int index = int.Parse(Console.ReadLine());

                SinglyLinkedList linkedList = new SinglyLinkedList();
                int llistCount = int.Parse(Console.ReadLine());

                for (int i = 0; i < llistCount; i++)
                {
                    int llistItem = int.Parse(Console.ReadLine());
                    linkedList.InsertNode(llistItem);

                }

                SinglyLinkedListNode extra = new SinglyLinkedListNode(-1);
                SinglyLinkedListNode temp = linkedList.head;

                for (int i = 0; i < llistCount; i++)
                {
                    if (i == index)
                    {
                        extra = temp;
                    }
                    if (i != llistCount - 1)
                    {
                        temp = temp.next;
                    }

                }
                temp.next = extra;

                bool result = hasCycyle(linkedList.head);
                Console.WriteLine(result ? 1 : 0);


            }
        }

        private static bool hasCycyle(SinglyLinkedListNode head)
        {
            if (head == null)
            {
                return false;
            }
            var fast = head;
            var slow = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (fast == slow)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
