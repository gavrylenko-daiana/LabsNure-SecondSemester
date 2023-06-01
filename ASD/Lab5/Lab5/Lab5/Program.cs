using System;

namespace Lab5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = { 9, 4, 7, 2, 1, 8, 6 };
            int n = arr.Length;

            Console.WriteLine("Original array is: ");
            PrintArray(arr);

            BuildMaxHeap(arr, n);

            Console.WriteLine("Max Heap array is: ");
            PrintArray(arr);

            ConvertMaxToMinHeap(arr, n);

            Console.WriteLine("Min Heap array is: ");
            PrintArray(arr);
        }

        public static void BuildMaxHeap(int[] arr, int n)
        {
            for (int i = (n - 2) / 2; i >= 0; --i)
                MaxHeapify(arr, i, n);
        }

        public static void MaxHeapify(int[] arr, int i, int n)
        {
            int l = left(i);
            int r = right(i);
            int largest = i;
            if (l < n && arr[l] > arr[i])
                largest = l;
            if (r < n && arr[r] > arr[largest])
                largest = r;
            if (largest != i)
            {
                Swap(ref arr[i], ref arr[largest]);
                MaxHeapify(arr, largest, n);
            }
        }

        public static void ConvertMaxToMinHeap(int[] arr, int n)
        {
            for (int i = (n - 2) / 2; i >= 0; --i)
                MinHeapify(arr, i, n);
        }

        public static void MinHeapify(int[] arr, int i, int n)
        {
            int l = left(i);
            int r = right(i);
            int smallest = i;
            if (l < n && arr[l] < arr[i])
                smallest = l;
            if (r < n && arr[r] < arr[smallest])
                smallest = r;
            if (smallest != i)
            {
                Swap(ref arr[i], ref arr[smallest]);
                MinHeapify(arr, smallest, n);
            }
        }

        public static int left(int i) { return (2 * i + 1); }

        public static int right(int i) { return (2 * i + 2); }

        public static void Swap(ref int x, ref int y)
        {
            (x, y) = (y, x);
        }

        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}