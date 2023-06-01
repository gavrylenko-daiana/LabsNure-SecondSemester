namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderedLinkedList list = new OrderedLinkedList();

            list.AddElement(19);
            list.AddElement(10);
            list.AddElement(8);
            list.AddElement(2);
            list.AddElement(13);
            list.AddElement(16);
            
            OrderedLinkedList list2 = new OrderedLinkedList();
            
            list2.AddElement(2);
            list2.AddElement(8);
            list2.AddElement(10);
            list2.AddElement(19);

            Console.Write("Created Linked List: ");
            list.DisplayElements();

            Console.Write("\nAfter removing an element at index 3: ");
            list.DeleteByIndex(3);
            list.DisplayElements();

            Console.Write("\nAfter removing element with value 3: ");
            list.DeleteByValue(3);
            list.DisplayElements();
            
            Console.Write("\n\nList 1: ");
            list.DisplayElements();
            Console.Write("\nList 2: ");
            list2.DisplayElements();

            Console.Write("\nChecking that the calling list L1 and the linked argument lists L2 are equal: ");
            bool testOnEqual= list.ListEqual(list2);
            Console.WriteLine(testOnEqual);
        }
    }
}