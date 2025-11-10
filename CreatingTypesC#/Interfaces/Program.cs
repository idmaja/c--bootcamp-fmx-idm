Console.WriteLine("--------------------------------------");
Console.WriteLine();

IAnimal dog = new Dog { Name = "Buddy" };
IAnimal cat = new Cat { Name = "Mimi" };

// dog.Speak();
// cat.Speak(); 

// Semua IAnimal bisa dimasukkan ke dalam 1 daftar
List<IAnimal> animals = new List<IAnimal> { dog, cat };

foreach (var a in animals)
    a.Speak(); // Memanggil Speak() dari tiap implementasi yang berbeda

Console.WriteLine("--------------------------------------");
Console.WriteLine();

IEnumerator e = new Countdown(); // Casts Countdown instance to IEnumerator interface
while (e.MoveNext())
    Console.Write(e.Current + " ");
