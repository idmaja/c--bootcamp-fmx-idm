public class Animal
{
    public virtual void Speak() { Console.WriteLine("Animal speaks"); }
}

public class Dog : Animal
{
    public override void Speak() { Console.WriteLine("Dog barks"); }
}

/* 
In this case, the Dog class overrides the Speak method defined in the Animal class. 
When a Dog object is treated as an Animal and its Speak method is called,
the Dog's specific Speak implementation (Dog barks) will be executed. 
*/