// ----------------------------------------------
// DEFAULT

// StringBuilder sb = new StringBuilder(); // sb references an object on the heap
// Foo(sb);                               // fooSB gets a copy of the reference to sb's object
// Console.WriteLine("sb: {0} \n", sb);      // Output: test (because Foo modified the object)

// static void Foo(StringBuilder fooSB)
// {
//     fooSB.Append("test"); // Modifies the object that sb *and* fooSB point to
//     fooSB = null;   // This only sets fooSB's reference to null; sb still points to the object
//     Console.WriteLine(fooSB);
// }
// After Foo, sb is NOT null, but the object it points to has "test" appended.


// ----------------------------------------------
// REF

// string x = "Penn";
// string y = "Teller";
// Swap(ref x, ref y);
// Console.Write(x); // Output: Teller
// Console.WriteLine(y + "\n"); // Output: Penn

// static void Swap(ref string a, ref string b)
// {
//     string temp = a;
//     a = b;
//     b = temp;
// }


// ----------------------------------------------
// OUT

// string a, b;
// Split("Stevie Ray Vaughan", out a, out b);
// Console.WriteLine(a + b + "\n"); // Output: Stevie RayVaughn
// // Console.WriteLine(b); // Output: Vaughn

// void Split(string name, out string firstNames, out string lastName)
// {
//     int i = name.LastIndexOf(' ');
//     firstNames = name.Substring(0, i);
//     lastName = name.Substring(i + 1);
// }


// ----------------------------------------------
// IN


// double ProcessData(in LargeData data)
// {
//     // Can read data but cannot modify it
//     // data.Description = "New"; // Compiler error!
//     return data.Values.Sum();
// }
// Console.WriteLine("hasil ProcessData: {0} \n", ProcessData(new LargeData { Values = [12, 14.5, 14, 16, 17] }));
// struct LargeData
// {
//     public double[] Values;
//     public string Description;
// }



// ----------------------------------------------
// COMBINING ALL PARAMETERS TYPE

ProcessOrder(1001, "John Doe", items: new[] {"Laptop", "Mouse"});
ProcessOrder(1002, "Jane Smith", 0.10m, true, "Phone", "Case", "Charger");
ProcessOrder(orderId: 1003, customerName: "Bob Wilson", expedited: true);

void ProcessOrder(int orderId, string customerName, 
                 decimal discount = 0.0m, 
                 bool expedited = false,
                 params string[] items) // items boleh kosong karena dia array
{
    Console.WriteLine($"Processing order {orderId} for {customerName}");
    Console.WriteLine($"Discount: {discount:P}, Expedited: {expedited}");
    Console.WriteLine($"Items: {(items.Length > 0 ? string.Join(", ", items) : "!!No Items!!")}\n");
}



// ----------------------------------------------
// PARAMS MODIFIER

Console.WriteLine("CalculateSum1: {0}", CalculateSum(1, 2, 3, 4, 5));
Console.WriteLine("CalculateSum2: {0}",CalculateSum(new int[] {1, 2, 3}));
Console.WriteLine("CalculateSum3: {0} \n", CalculateSum() > 0 ? CalculateSum() : 0); // Empty array, output : 0 karena defaultnya int 0

int CalculateSum(params int[] numbers)
{
    return numbers.Sum();
}


Console.WriteLine("--- Scenario 2: Configuration Parser ---");
var configData = "server=localhost;port=5432;database=my app;timeout=30";
var config = ParseConfiguration(configData);
foreach (var pair in config) { Console.WriteLine($"{pair.Key}: {pair.Value}"); }

static Dictionary<string, string> ParseConfiguration(string configString)
{
    var result = new Dictionary<string, string>();
    var pairs = configString.Split(';');
    
    foreach (var pair in pairs)
    {
        var keyValue = pair.Split('=');
        Console.WriteLine("keyValue[1]: {0}", keyValue[1].Trim());
        if (keyValue.Length == 2)
        {
            result[keyValue[0].Trim()] = keyValue[1].Trim();
        }
    }
    
    return result;
}



