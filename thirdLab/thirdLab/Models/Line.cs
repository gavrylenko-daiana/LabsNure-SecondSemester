namespace thirdLab.Models;

public class Line : Figure
{
    private Point Start { get; set; }
    private Point End { get; set; }

    public Line(Point start, Point end)
    {
        Start = start;
        End = end;
    }

    public override double GetPerimeter()
    {
        return Math.Round(Math.Sqrt(Math.Pow(End.X - Start.X, 2) + Math.Pow(End.Y - Start.Y, 2)));
    }

    public override double GetArea()
    {
        return 0;
    }

    public override void MoveBy(double x, double y)
    {
        Start.X += x;
        Start.Y += y;
        End.X += x;
        End.Y += y;
    }

    public override void MoveTo(double x, double y)
    {
        var xOffset = x - Start.X;
        var yOffset = y - Start.Y;
        Start.X += xOffset;
        Start.Y += yOffset;
        End.X += xOffset;
        End.Y += yOffset;
    }

    public override void GetInfo()
    {
        Console.WriteLine($"Class: Line, Length: {GetPerimeter()}, Start coordinates: ({Start.X}, {Start.Y}), End coordinates: ({End.X}, {End.Y}), Color: {Color}");
    }
    
    public void Scale(double scaleX, double scaleY)
    {
        End.X += scaleX;
        End.Y += scaleY;
    }

    public override Point[] GetPoints()
    {
        return new Point[] { Start, End };
    }
}