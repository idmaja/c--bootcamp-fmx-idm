using System.Collections;

class Car
{
    public string VIN { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
}


Book myBook = new Book();
myBook.Title = "1984";
myBook.Author = "George Orwell";
myBook.ISBN = "0-000-00000-0";

Car car1 = new Car();
car1.Make = "Ford";
car1.Model = "Mustang";
car1.VIN = "A1";

Car car2 = new Car();
car2.Make = "Chevrolet";
car2.Model = "Camaro";
car2.VIN = "B2";


// ------ OLD WAY USING NON-GENERIC COLLECTION ------
// ArrayList myCollection = new ArrayList();
// myCollection.Add(myBook);
// myCollection.Add(car1);
// myCollection.Add(car2);

// foreach (object obj in myCollection)
// {
//     if (obj is Book)
//     {
//         Book b = (Book)obj;
//         Console.WriteLine("Book: {0} by {1}", b.Title, b.Author);
//     }
//     else if (obj is Car)
//     {
//         Car c = (Car)obj;
//         Console.WriteLine("Car: {0} {1}", c.Make, c.Model);
//     }
// }




// ------ NEW WAY USING GENERIC COLLECTION --------
// List<Book> myBookCollection = new List<Book>();
// myBookCollection.Add(myBook);
// // myBookCollection.Add(car1); // Tidak bisa karena tipe berbeda
// // myBookCollection.Add(car2); // Tidak bisa karena tipe berbeda

// foreach (Book b in myBookCollection)
// {
//     Console.WriteLine("Book: {0} by {1}", b.Title, b.Author);
// }





// ------ DICTIONARY ------
// Dictionary<string, Car> myCarDictionary = new Dictionary<string, Car>();
// myCarDictionary.Add(car1.VIN, car1);
// myCarDictionary.Add(car2.VIN, car2);

// Console.WriteLine("Car A1 Make: {0}", myCarDictionary["A1"].Make); // Output: Ford





// Object Initializers
Car car3 = new Car() { Make = "BMW", Model = "M3", VIN = "C3" };
Console.WriteLine("Car C3 Make: {0}", car3.Make); // Output: BMW




// Collection Initializers
List<Car> carList = new List<Car>()
{
    new Car() { Make = "Audi", Model = "A4", VIN = "D4" },
    new Car() { Make = "Mercedes", Model = "C-Class", VIN = "E5" }
};
foreach (Car c in carList)
{
    Console.WriteLine("Car: {0} {1}", c.Make, c.Model);
}

Console.WriteLine(carList.Count());