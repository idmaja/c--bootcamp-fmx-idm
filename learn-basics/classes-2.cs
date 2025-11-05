class Car
{
    public string Make { get; set; } = "Nissan";
    public string Model { get; set; } = "Altima";
    public int Year { get; set; } = 2022;
    public string Color { get; set; } = "Black";

    public decimal DetermineMarketValue()
    {
        decimal carValue = 100.0M;
        if (Year > 1990 && Year < 2000)
            carValue *= 1.2M;
        else
            carValue = 200M;

        return carValue;
    }

    public void DisplayInfo()
    {
        Console.WriteLine(Make + " " + Model + " " + Year + " " + Color);
    }
}

Car myCar = new Car();
myCar.Make = "Toyota";
myCar.Model = "Camry";
myCar.Year = 2020;
myCar.Color = "Blue";
Console.WriteLine("My car is a {0} {1} {2} {3} (1).", myCar.Color, myCar.Year, myCar.Make, myCar.Model);
// myCar.DisplayInfo();

myCar = null;

Console.WriteLine("My car is a {0} {1} {2} {3} (2).", myCar?.Color, myCar?.Year, myCar?.Make, myCar?.Model);

// ---------------------------------------------------------------------------

// Car MyOtherCar;
// MyOtherCar = myCar;
// MyOtherCar.Color = "Red";

// // MyOtherCar = null;
// Console.WriteLine("My other car is a {0} {1} {2} {3} (1).", MyOtherCar.Color, MyOtherCar.Year, MyOtherCar.Make, MyOtherCar.Model);
// myCar = null;
// MyOtherCar.Make = "Honda";
// MyOtherCar.Model = "Accord";
// MyOtherCar.Year = 2021;

// Console.WriteLine("My car is a {0} {1} {2} {3}.", myCar.Color, myCar.Year, myCar.Make, myCar.Model);
// Console.WriteLine("My other car is a {0} {1} {2} {3}.", MyOtherCar.Color, MyOtherCar.Year, MyOtherCar.Make, MyOtherCar.Model);

// decimal value = DetermineMarketValue(myCar);
// Console.WriteLine("{0:C}", value);

// Console.WriteLine("{0:C}", myCar.DetermineMarketValue());
