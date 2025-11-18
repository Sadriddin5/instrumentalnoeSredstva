using System;
using System.Collections.Generic;
var editor = new GraphicEditor();
var circle = new Circle(10, 20, "Red", 15);
var rectangle = new Rectangle(30, 40, "Blue", 25, 35);
var line = new Line(5, 5, 50, 50, "Green", 2);

editor.AddObject(circle);
editor.AddObject(rectangle);
editor.AddObject(line);

Console.WriteLine("Оригинальные объекты:");
editor.DisplayAllObjects();

var circleCopy = editor.CopyObject(0);
var rectangleCopy = editor.CopyObject(1);

if (circleCopy is Circle copiedCircle)
{
    copiedCircle.X = 100;
    copiedCircle.Color = "Yellow";
}

if (rectangleCopy is Rectangle copiedRect)
{
    copiedRect.Width = 50;
    copiedRect.Height = 30;
}
editor.AddObject(circleCopy);
editor.AddObject(rectangleCopy);
Console.WriteLine("\nПосле копирования и модификации:");
editor.DisplayAllObjects();

Console.WriteLine("\nПроверка глубокого копирования:");
Console.WriteLine("Оригинал круга: " + circle.Color + ", позиция: " + circle.X);
Console.WriteLine("Копия круга: " + circleCopy.Color + ", позиция: " + circleCopy.X);

Console.WriteLine("\nОригинал прямоугольника: " + rectangle.Width + "x" + rectangle.Height);
Console.WriteLine("Копия прямоугольника: " + ((Rectangle)rectangleCopy).Width + "x" +
                 ((Rectangle)rectangleCopy).Height);

public abstract class GraphicObject : ICloneable
{
    public int X { get; set; }
    public int Y { get; set; }
    public string Color { get; set; }
    public GraphicObject(int x, int y, string color)
    {
        X = x;
        Y = y;
        Color = color;
    }
    public abstract GraphicObject Clone();
    object ICloneable.Clone()
    {
        return Clone();
    }
    public virtual void Display()
    {
        Console.WriteLine($"Объект на позиции ({X}, {Y}), цвет: {Color}");
    }
}
public class Circle : GraphicObject
{
    public int Radius { get; set; }
    public Circle(int x, int y, string color, int radius) : base(x, y, color)
    {
        Radius = radius;
    }
    public override GraphicObject Clone()
    {
       
        return new Circle(X, Y, Color, Radius);
    }
    public override void Display()
    {
        Console.WriteLine($"Круг в позиции ({X}, {Y}), радиус: {Radius}, цвет: {Color}");
    }
}
public class Rectangle : GraphicObject
{
    public int Width { get; set; }
    public int Height { get; set; }
    public Rectangle(int x, int y, string color, int width, int height) : base(x, y, color)
    {
        Width = width;
        Height = height;
    }
    public override GraphicObject Clone()
    {
        return new Rectangle(X, Y, Color, Width, Height);
    }
    public override void Display()
    {
        Console.WriteLine($"Прямоугольник в позиции ({X}, {Y}), размер: {Width}x{Height}, цвет: {Color}");
    }
}

public class Line : GraphicObject
{
    public int X2 { get; set; }
    public int Y2 { get; set; }
    public int Thickness { get; set; }
    public Line(int x1, int y1, int x2, int y2, string color, int thickness)
        : base(x1, y1, color)
    {
        X2 = x2;
        Y2 = y2;
        Thickness = thickness;
    }
    public override GraphicObject Clone()
    {
        return new Line(X, Y, X2, Y2, Color, Thickness);
    }
    public override void Display()
    {
        Console.WriteLine($"Линия от ({X}, {Y}) до ({X2}, {Y2}), толщина: {Thickness}, цвет: {Color}");
    }
}
public class GraphicEditor
{
    private List<GraphicObject> _objects = new List<GraphicObject>();
    public void AddObject(GraphicObject obj)
    {
        _objects.Add(obj);
    }
    public GraphicObject CopyObject(int index)
    {
        if (index >= 0 && index < _objects.Count)
        {
            return _objects[index].Clone();
        }
        return null;
    }
    public void DisplayAllObjects()
    {
        Console.WriteLine("Все объекты в редакторе:");
        for (int i = 0; i < _objects.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            _objects[i].Display();
        }
    }
}



       