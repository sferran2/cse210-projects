using System;

class Program
{
    static void Main(string[] args)
    {
        Square aSquare = new Square();
        aSquare.SetColor("red");
        aSquare.SetSide(5);

        Rectangle aRectangle = new Rectangle();
        aRectangle.SetColor("green");
        aRectangle.SetLength(3);
        aRectangle.SetWidth(5);

        Circle aCircle = new Circle();
        aCircle.SetColor("yellow");
        aCircle.SetRadius(4);

        DisplayColor(aSquare);
        DisplayColor(aRectangle);
        DisplayColor(aCircle);
    }

    public static void DisplayColor(Shape shape)
    {
        double area = shape.GetArea();
        Console.WriteLine($" The {shape.GetColor()} shape has an area of {area}");
    }

}