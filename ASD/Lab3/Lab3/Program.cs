using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List(10);

            Console.WriteLine("Is the list empty? " + list.IsEmpty());
            Console.WriteLine("Is the list full? " + list.IsFull());

            list.Add(5);
            list.Add(13);
            list.Add(8);
            list.Add(11);
            list.Add(16);

            Console.WriteLine("List content before sorting:");
            list.PrintList();

            list.HeapSort();

            Console.WriteLine("List content after sorting:");
            list.PrintList();

            Console.WriteLine("Size of the list: " + list.Size());
            Console.WriteLine();

            
            PriorityQueue queue = new PriorityQueue(10);

            Console.WriteLine("Is the queue empty? " + queue.IsEmpty());
            Console.WriteLine("Is the queue full? " + queue.IsFull());

            queue.Enqueue(3, 5);
            queue.Enqueue(1, 13);
            queue.Enqueue(4, 8);
            queue.Enqueue(2, 11);
            queue.Enqueue(5, 16);

            Console.WriteLine("Queue content:");
            queue.PrintQueue();

            (int priority, int value) maxElement = queue.DequeueMax();
            Console.WriteLine($"Dequeued max element: ({maxElement.priority}, {maxElement.value})");

            Console.WriteLine("Queue content after dequeuing max element:");
            queue.PrintQueue();

            Console.WriteLine("Size of the queue: " + queue.Size());
        }
    }
}