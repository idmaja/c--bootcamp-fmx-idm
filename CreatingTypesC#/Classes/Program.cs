// Car toyota = new Car("Camry", "Toyota", 2000, "2002", DateTime.Now);
// Car suzuki = new Car("APV", "Suzuki", 1500, "2024", DateTime.Today);

// Console.WriteLine(toyota.Status);

// toyota.DetailedInfo();
// suzuki.DetailedInfo();

Console.WriteLine();
Console.WriteLine("------------------------------------");

Store milikDina = new Store("Store Dina", "Jl. Karawaci No.19, Tangerang", "088736361881");
Store milikTony = new Store("Store Tony", "Jl. Karawaci No.20, Tangerang", "0887363124381");

milikDina.Close();
milikDina.PrintStoreInfo();
Console.WriteLine();
milikTony.PrintStoreInfo();

Console.WriteLine();
Console.WriteLine($"Total Stores Count : {Store.PrintStoreCount()}");

Console.WriteLine("------------------------------------");
Console.WriteLine();

int sum = Calculator.Add(2, 3);
Console.WriteLine($"Sum: {sum}");

// instance method dengan ref dan out
var calc = new Calculator();
calc.DemoInternalMethods();

// inheritance
Shape s = new Circle(2.0);
Console.WriteLine($"Area: {s.Area()}");
s.PrintName();

var weird = new WeirdCircle(1.0);
weird.PrintName();

var special = new SpecialCircle(1.0);
special.PrintName();

// partial
var processor = new OrderProcessor();
processor.Process(101);

Console.WriteLine("------------------------------------");
Console.WriteLine();