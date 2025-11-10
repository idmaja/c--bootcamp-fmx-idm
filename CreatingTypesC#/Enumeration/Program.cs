Toppings order = Toppings.Cheese | Toppings.Pepperoni;
Console.WriteLine($"ORDER (int) : {(int)order}"); // Output: 5 (1 + 4)
Console.WriteLine($"ORDER : {order}"); // Output: Cheese, Pepperoni
Console.WriteLine($"TOPPING CHEESE (int) : {(int)Toppings.Cheese}"); // Output: 1
Console.WriteLine($"TOPPING CHEESE : {Toppings.Cheese}");

if ((order & Toppings.Cheese) != 0)
    Console.WriteLine("Customer wants cheese.");

// Console.WriteLine(sides.ToString().Split()); 

string[] sidesArray = order.ToString().Split([',']);
Console.WriteLine(sidesArray.Length);
foreach (string item in sidesArray)
{
    Console.WriteLine(item.Trim()); 
}

