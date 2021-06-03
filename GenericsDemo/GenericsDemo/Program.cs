using System;
using System.Collections.Generic;
using LinkedList;
using GenericHeap;

namespace GenericsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //DavidLinkedList<string> firstList = new DavidLinkedList<string>();

            //firstList.Add("Alice");
            //firstList.Add("Bob");
            //firstList.Add("Clarice");
            //firstList.Add("David");
            //firstList.Add("Elizabeth");

            //foreach (string temp in firstList)
            //{
            //    Console.WriteLine(temp);
            //}

            //foreach (string temp in firstList)
            //{
            //    Console.WriteLine(temp);
            //}


            //foreach (string temp in firstList)
            //{
            //    Console.WriteLine(temp);
            //}

            MinHeap<int> firstHeap = new MinHeap<int>();

            firstHeap.Add(30);
            firstHeap.Add(5);
            firstHeap.Add(10);
            firstHeap.Add(15);
            firstHeap.Add(20);
            firstHeap.Add(25);
            

            Console.WriteLine(firstHeap.Peek());

            firstHeap.Add(2);
            

            Console.WriteLine(firstHeap.Peek());
            

        }
    }
}
