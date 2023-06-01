namespace thirdLab.Models;

public abstract class Figure
{
    public string Color { get; set; } = "white";

    public abstract double GetPerimeter();
    public abstract double GetArea();
    public abstract void MoveBy(double x, double y);
    public abstract void MoveTo(double x, double y);
    public abstract void GetInfo();
    public abstract Point[] GetPoints();
}