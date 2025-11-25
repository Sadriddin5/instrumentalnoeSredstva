
        IShape shape = new Rectangle(30, 40);
        IShape clonedShape = shape.Clone();
        shape.GetInfo();
        clonedShape.GetInfo();

        shape = new Circle(30);
        clonedShape = shape.Clone();
        shape.GetInfo();
        clonedShape.GetInfo();

        Console.Read();


interface IShape
{
    IShape Clone();
    void GetInfo();
}

class Rectangle : IShape
{
    int width;
    int height;

    public Rectangle(int w, int h)
    {
        width = w;
        height = h;
    }

    public IShape Clone()
    {
        return new Rectangle(width, height);
    }

    public void GetInfo()
    {
        Console.WriteLine($"Прямоугольник шириной {width} и высотой {height}");
    }
}

class Circle : IShape
{
    int radius;

    public Circle(int r)
    {
        radius = r;
    }

    public IShape Clone()
    {
        return new Circle(radius);
    }

    public void GetInfo()
    {
        Console.WriteLine($"Круг радиусом {radius}");
    }
}
