namespace thirdLab.Models;

public class Rhombus : Figure
{
    private Point Top { get; set; }
    private Point Bottom { get; set; }
    private Point Left { get; set; }
    private Point Right { get; set; }

    public Rhombus(Point top, Point bottom, Point left, Point right)
    {
        Top = top;
        Bottom = bottom;
        Left = left;
        Right = right;

        if (Math.Abs(Top.X - Right.Y) != Math.Abs(Left.X - Bottom.Y))
        {
            throw new ArgumentException("The Figure you defined with the coordinates doesn't seem to be a rhombus");
        }
    }

    public override double GetPerimeter()
    {
        return Math.Round((Math.Sqrt(Math.Pow(Right.X - Left.X, 2) + Math.Pow(Right.Y - Left.Y, 2))) * 4, 4);
    }

    public override double GetArea()
    {
        return Math.Round((Math.Abs(Right.X - Left.X) * Math.Abs(Top.Y - Bottom.Y)) / 2, 4);
    }


    public override void MoveBy(double x, double y)
    {
        foreach (var point in GetPoints())
        {
            point.X += x;
            point.Y += y;
        }
    }

    public override void MoveTo(double x, double y)
    {
        var xOffset = x - Top.X;
        var yOffset = y - Top.Y;

        foreach (var point in GetPoints())
        {
            point.X += xOffset;
            point.Y += yOffset;
        }
    }

    public override void GetInfo()
    {
        Console.WriteLine($"Class: Rhombus, Area: {GetArea()}, Perimeter: {GetPerimeter()}, Top coordinates: ({Top.X}, {Top.Y}), Bottom coordinates: ({Bottom.X}, {Bottom.Y}), Left coordinates: ({Left.X}, {Left.Y}), Right coordinates: ({Right.X}, {Right.Y}), Color: {Color}");
    }

    public override Point[] GetPoints()
    {
        return new Point[] { Top, Bottom, Left, Right };
    }
    
    public void Scale(double scaleX, double scaleY)
    {
        Right.X += scaleX / 2;
        Left.X -= scaleX / 2;
        Top.Y += scaleY / 2;
        Bottom.Y += scaleY / 2;
    }
}
