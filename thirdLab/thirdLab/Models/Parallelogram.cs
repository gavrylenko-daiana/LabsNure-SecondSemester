namespace thirdLab.Models;

public class Parallelogram : Figure
{
    private Point BottomLeft { get; set; }
    private Point BottomRight { get; set; }
    private Point TopRight { get; set; }
    private Point TopLeft { get; set; }

    public Parallelogram(Point bottomLeft, Point bottomRight, Point topRight, Point topLeft)
    {
        BottomLeft = bottomLeft;
        BottomRight = bottomRight;
        TopRight = topRight;
        TopLeft = topLeft;

        if (Math.Abs(BottomRight.X - BottomLeft.X) != Math.Abs(TopRight.X - TopLeft.X)
            || Math.Abs(BottomRight.Y - BottomLeft.Y) != Math.Abs(TopRight.Y - TopLeft.Y))
        {
            throw new ArgumentException("The Figure you defined with the coordinates doesn't seem to be a parallelogram");
        }
    }

    public override double GetPerimeter()
    {
        return Math.Round((Math.Abs(BottomRight.X - BottomLeft.X) + Math.Abs(BottomRight.Y - TopRight.Y)) * 2, 4);
    }

    public override double GetArea()
    {
        return Math.Round(Math.Abs(BottomRight.X - BottomLeft.X) * Math.Abs(TopRight.Y - BottomRight.Y), 4);
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
        var xOffset = x - BottomLeft.X;
        var yOffset = y - BottomLeft.Y;

        foreach (var point in GetPoints())
        {
            point.X += xOffset;
            point.Y += yOffset;
        }
    }

    public override void GetInfo()
    {
        Console.WriteLine($"Class: Parallelogram, Area: {GetArea()}, Perimeter: {GetPerimeter()}, Bottom Left coordinates: ({BottomLeft.X}, {BottomLeft.Y}), Bottom Right coordinates: ({BottomRight.X}, {BottomRight.Y}), Top Right coordinates: ({TopRight.X}, {TopRight.Y}), Top Left coordinates: ({TopLeft.X}, {TopLeft.Y}), Color: {Color}");
    }

    public override Point[] GetPoints()
    {
        return new Point[] { BottomLeft, BottomRight, TopRight, TopLeft };
    }

    public void Scale(double scaleX, double scaleY)
    {
        BottomRight.X += scaleX;
        TopRight.X += scaleX;
        TopLeft.Y += scaleY;
        TopRight.Y += scaleY;
    }
}
