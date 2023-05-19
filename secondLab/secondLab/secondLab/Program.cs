using System.Threading.Channels;

namespace secondLab;

class Program
{
    static void Main(string[] args)
    {
        RList list = new RList(4);
        
        list.AddFirst(19);
        list.AddFirst(9);
        list.AddFirst(11);
        list.AddFirst(14);
        list.AddFirst(11);
        list.AddFirst(3);

        list.PrintList();
        Console.WriteLine();

        list.AddBeforeByValue(5, 11);

        list.PrintList();


        // list.AddFirst(3);
        // list.AddFirst(12);
        // list.AddFirst(7);
        //
        // list.PrintList();
        //
        // Console.WriteLine("\n\nList elements in reverse order:");
        // list.PrintReverse();
        //
        // list.AddNewElementByIndex(15, -3);
        //
        // Console.WriteLine("\nList elements after adding 2th element:");
        // list.PrintList();
        //
        // list.Remove(12);
        //
        // Console.WriteLine("\n\nList elements after removing element with value 12 (the first of several):");
        // list.PrintList();
        //
        // int index = list.Find(4);
        // Console.WriteLine("\n\nIndex of element with value 4: " + index);
        //
        // // зчитуємо значення останнього елемента
        // int? last = list.Last;
        // Console.WriteLine("\nLast element value: " + last);
        //
        // list.Last = 10;
        //
        // Console.WriteLine("\nList elements after setting last element value to 10:");
        // list.PrintList();
        //
        // list++;
        // Console.WriteLine("\n\nList elements after using the increment operator: ");
        // list.PrintList();
        //
        // // Console.WriteLine($"\n\nThe list before using method Clear: ");
        // // list.Clear();
        //
        // RList resultList = list + (-4) ?? throw new InvalidOperationException();
        //
        // Console.WriteLine("\n\nElements of combined list:");
        // resultList.PrintList();
    }
}