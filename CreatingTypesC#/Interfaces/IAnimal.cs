// Interface: hanya mendefinisikan kontrak, tanpa isi
public interface IAnimal
{
    void Speak();              // Method
    string Name { get; set; }  // Property
}

public class Dog : IAnimal
{
    public string Name { get; set; }

    public void Speak()
    {
        Console.WriteLine($"{Name} says: Woof!");
    }
}

public class Cat : IAnimal
{
    public string Name { get; set; }

    public void Speak()
    {
        Console.WriteLine($"{Name} says: Meow!");
    }
}
