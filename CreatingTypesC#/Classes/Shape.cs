
/// <summary>
/// Inheritance modifiers
/// virtual, override, new, abstract, sealed
/// </summary>


// abstract class dengan abstract method
public abstract class Shape
{
    public abstract double Area(); // abstract method
    public virtual void PrintName() // virtual method
    {
        Console.WriteLine("Shape");
    }
}

// override method
public class Circle : Shape
{
    public double Radius;

    public Circle(double radius)
    {
        Radius = radius;
        Console.Write("Base Constructor of Circle has been called : ");
    }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public override void PrintName()
    {
        Console.WriteLine("Circle");
    }
}

// new untuk menyembunyikan method base
public class WeirdCircle : Circle
{
    public WeirdCircle(double radius) : base(radius) { }

    public new void PrintName() // menyembunyikan PrintName dari Circle
    {
        Console.WriteLine("WeirdCircle");
    }
}

// sealed override, turunan lagi tidak boleh override method ini
public class SpecialCircle : Circle
{
    public SpecialCircle(double radius) : base(radius) { }

    public sealed override void PrintName()
    {
        Console.WriteLine("SpecialCircle");
    }
}