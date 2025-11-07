
/// <summary>
/// Car class demonstrating constructor overloading and chaining
/// Shows how you can create multiple ways to build the same type of object
/// Think of it like different car dealership packages - basic, standard, or premium
/// </summary>

public interface ICar
{
    void Accelerate(int delta);
}

public enum Status
{
    Ready,
    InProgress,
    Completed
}


public class Car : ICar
{
    static readonly int MaxSpeed = 200;

    private string? Merk { get; set; }
    private readonly string _model;
    private readonly double _mileage = 0.0;

    public string? Year { get; set; }
    public int CurrentSpeed { get; set; }
    public DateTime BirthDate { get; init; } = DateTime.Now;
    public readonly string CEO = "YTTA";
    public Status Status { get; set; }
    public string Description => $"This car is a {Merk} {Model} made in {BirthDate.Year} by {CEO}";

    public Car()
    {
        _model = "Default Model";
        Console.WriteLine("Default constructor called");
    }

    public Car(string model, string merk, int currentSpeed, string year, DateTime birthDate)
    {
        this._model = model;
        Merk = merk;
        CurrentSpeed = currentSpeed;
        Year = year;
        BirthDate = birthDate;
        Status = Status.Ready;
    }

    public string Model => _model;
    public double Milleage => _mileage;

    public void Accelerate(int delta)
    {
        if (CurrentSpeed + delta <= MaxSpeed)
        {
            CurrentSpeed += delta;
        }
        else
        {
            CurrentSpeed = MaxSpeed;
        }

        Console.WriteLine($"Current speed is {CurrentSpeed}");
        Console.WriteLine($"Max speed is {MaxSpeed}");
    }

    public void DetailedInfo()
    {
        Console.WriteLine($"This car is a {Merk} {Model} {Year} made in {BirthDate.Year} with speed {CurrentSpeed} by {CEO}");
    }

    public bool IsReadyForSale()
    {
        if (CurrentSpeed == 0 && Status == Status.Ready)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}


// public class Panda
// {
//     public Panda? Mate;
//     public void Marry(Panda partner)
//     {
//         Mate = partner;     // Sets the Mate of the current object
//         partner.Mate = this; // Sets the Mate of the partner object to the current object 
//     }
// }


