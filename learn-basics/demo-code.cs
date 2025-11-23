var rand = new Random();

bool horizontal = rand.Next(2) == 0;
int length = rand.Next(2);

Console.WriteLine("Drawing a " + (horizontal ? "horizontal" : "vertical") + " line.");
Console.WriteLine("Length: " + length);