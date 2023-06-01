namespace thirdLab.Models;

public class Trapezoid : Figure
{
    private Point TopLeft { get; set; }
    private Point TopRight { get; set; }
    private Point BottomLeft { get; set; }
    private Point BottomRight { get; set; }

    public Trapezoid(Point topLeft, Point topRight, Point bottomLeft, Point bottomRight)
    {
        TopLeft = topLeft;
        TopRight = topRight;
        BottomLeft = bottomLeft;
        BottomRight = bottomRight;

        if (topLeft.Y != topRight.Y || bottomLeft.Y != bottomRight.Y)
        {
            throw new ArgumentException("The Figure you defined with the coordinates doesn't seem to be a trapezoid");
        }
    }

    public override double GetPerimeter()
    {
        return Math.Round(Math.Sqrt(Math.Pow(TopRight.X - TopLeft.X, 2) + Math.Pow(TopRight.Y - TopLeft.Y, 2)) +
            Math.Sqrt(Math.Pow(BottomRight.X - BottomLeft.X, 2) + Math.Pow(BottomRight.Y - BottomLeft.Y, 2)) +
            Math.Abs(BottomLeft.X - TopLeft.X) + Math.Abs(BottomRight.X - TopRight.X), 4);
    }

    public override double GetArea()
    {
        return Math.Round((Math.Abs(BottomRight.X - BottomLeft.X) + Math.Abs(TopRight.X - TopLeft.X)) * Math.Abs(BottomLeft.Y - TopLeft.Y) / 2, 4);
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
        var xOffset = x - TopLeft.X;
        var yOffset = y - TopLeft.Y;

        foreach (var point in GetPoints())
        {
            point.X += xOffset;
            point.Y += yOffset;
        }
    }

    public override void GetInfo()
    {
        Console.WriteLine($"Class: Trapezoid, Area: {GetArea()}, Perimeter: {GetPerimeter()}, Top Left coordinates: ({TopLeft.X}, {TopLeft.Y}), Top Right coordinates: ({TopRight.X}, {TopRight.Y}), Bottom Left coordinates: ({BottomLeft.X}, {BottomLeft.Y}), Bottom Right coordinates: ({BottomRight.X}, {BottomRight.Y}), Color: {Color}");
    }

    public override Point[] GetPoints()
    {
        return new Point[] { TopLeft, TopRight, BottomLeft, BottomRight };
    }
    
    public void Scale(double scaleX, double scaleY)
    {
        TopLeft.X -= scaleX / 2;
        TopRight.X += scaleX / 2;
        BottomRight.X += scaleX / 2;
        BottomLeft.X -= scaleX / 2;

        TopLeft.Y += scaleY / 2;
        TopRight.Y += scaleY / 2;
        BottomRight.Y -= scaleY / 2;
        BottomLeft.Y -= scaleY / 2;
    }
}