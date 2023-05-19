using System;
using thirdLab;
using thirdLab.Models;

public class Program
{
    static void Main(string[] args)
    {
        var line = new Line(new Point(0, 0), new Point(5, 10));
        line.Color = "blue";
        line.GetInfo();
        line.MoveBy(10,0);
        line.Color = "black";
        line.GetInfo();
        line.Scale(3, 0);

        Console.WriteLine();

        var parallelogram = new Parallelogram(new Point(2, 2), new Point(6, 2), new Point(8, 5), new Point(4, 5));
        parallelogram.Color = "green";
        parallelogram.GetInfo();
        parallelogram.MoveTo(1, 2);
        parallelogram.GetInfo();
        parallelogram.GetInfo();

        Console.WriteLine();
        
        var rhombus = new Rhombus(new Point(0, 1), new Point(0, -1), new Point(-1, 0), new Point(1, 0));
        rhombus.Color = "yellow";
        rhombus.GetInfo();
        rhombus.MoveTo(5, 1);
        parallelogram.Scale(2, 0);
        rhombus.GetInfo();

        Console.WriteLine();

        var trapezoid = new Trapezoid(new Point(0, 0), new Point(4, 0), new Point(2, 2), new Point(1, 2));
        trapezoid.Color = "red";
        trapezoid.GetInfo();
        trapezoid.MoveBy(1, 1);
        trapezoid.GetInfo();
    }
}
