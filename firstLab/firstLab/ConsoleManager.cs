namespace firstLab;

public class ConsoleManager
{
    protected static int RequestUser(string message)
    {
        Console.Write(message);
        return Convert.ToInt32((Console.ReadLine()));
    }

    protected static int RandomValue()
    {
        Random rand = new Random();
        return rand.Next(0, 4);
    }

    protected static void ApplyColor(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}