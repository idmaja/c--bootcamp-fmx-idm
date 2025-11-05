public abstract class Animal // Abstract class
{
    public abstract void MakeSound(); // Abstract method (no implementation)
}

public class Dog : Animal
{
    public override void MakeSound() { Console.WriteLine("Woof!"); } // Concrete implementation
}

/*
The Animal class is declared as abstract and defines an abstract method MakeSound(). 
This signifies that any class inheriting from Animal must provide its own concrete implementation for MakeSound(). 
The Dog class then provides this specific implementation, hiding the internal mechanics of how a dog makes its sound.
*/