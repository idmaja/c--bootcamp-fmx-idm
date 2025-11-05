class Car
{
    public string VIN { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
}

List<Car> carList = new List<Car>()
{
    new Car() { Make = "Audi", Model = "A4", VIN = "D4" },
    new Car() { Make = "Mercedes", Model = "C-Class", VIN = "E5" },
    new Car() { Make = "BMW", Model = "M3", VIN = "C3" },
    new Car() { Make = "BMW", Model = "X5", VIN = "F6" },
    new Car() { Make = "BMW", Model = "M3", VIN = "G7" },
};

var samsungCars = from car in carList
                  where car.Make == "Samsung"
                  select car;

var otherCars = from c in carList
                where c.Make == "Samsung"
                select new { c.Make, c.Model };
                  
foreach (var car in otherCars)
{
    Console.WriteLine("Car Make: {0}, Model: {1}", car.Make, car.Model);
}

var bmwCars = carList.Where(car => car.Make == "BMW").TakeLast(2).OrderBy(car => car.Model);
carList.ForEach(car => Console.WriteLine("Car Make: {0}, Model: {1}, VIN: {2}", car.Make, car.Model, car.VIN));
Console.WriteLine(carList.TrueForAll(car => car.VIN != null)); // Harus di Console.WriteLine karena mengembalikan bool
Console.WriteLine(carList.Any(car => car.Model == "A4"));
Console.WriteLine(carList.Exists(car => car.Make == "Mercedes"));
Console.WriteLine(carList.Count(car => car.Make == "BMW"));
Console.WriteLine(carList.Sum(car => car.Model.Length));
Console.WriteLine(carList.Average(car => car.VIN.Length));
Console.WriteLine(carList.Min(car => car.Model));
Console.WriteLine(carList.Max(car => car.Make));
Console.WriteLine(carList.GetType().Namespace);

var groupedByMake = carList.GroupBy(car => car.Make);
// foreach (var group in groupedByMake)
// {
//     Console.WriteLine("Make: {0}, Count: {1}", group.Key, group.Count());
// }

var orderedCars = carList.OrderBy(car => car.Make).ThenByDescending(car => car.Model);
Console.WriteLine(orderedCars.GetType());


// foreach (var car in bmwCars)
// {
//     Console.WriteLine("BMW Car Found: {0} {1} with VIN {2}", car.Make, car.Model, car.VIN);
// }