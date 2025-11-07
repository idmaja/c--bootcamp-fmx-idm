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

Console.WriteLine($"Total Stores Count : {Store.StoreCount}");

Console.WriteLine();
