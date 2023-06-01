namespace Lab2;

class Program
{
    static void Main(string[] args)
    {
        BBST tree = new BBST(10);
        BBSTOperations operations = new BBSTOperations();
      
        operations.Insert(tree, 6);
        operations.Insert(tree, 12);
        operations.Insert(tree, 7);
        operations.Insert(tree, 2);
        operations.Insert(tree, 5);
        operations.Insert(tree, 18);
        operations.Insert(tree, 15);
        operations.Insert(tree, 4);

        operations.PrintPreOrder(tree);
        Console.WriteLine();
        operations.PrintInOrder(tree);
        Console.WriteLine();
        operations.PrintPostOrder(tree);
        Console.WriteLine();
        operations.Print(tree);
        
        BBST balancedTree = operations.Balance(tree);
        Console.WriteLine("Balanced tree:");
        operations.Print(balancedTree);
        Console.WriteLine();

        Console.WriteLine(operations.Search(tree, 2));
        Console.WriteLine(operations.Search(tree, 8));
        
        operations.Remove(tree, null, 6);
        operations.PrintInOrder(tree);

        Console.WriteLine();
        Console.WriteLine($"The number of nodes in the tree: {operations.Count(tree)}");

        Console.WriteLine($"The height of the tree: {operations.Height(tree)}");

        tree = operations.DeleteEven(tree);
        operations.PrintInOrder(tree);
    }
}
