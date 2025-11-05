// string a;
// Split("Stevie Ray Vaughan", out a, out _);
// Console.WriteLine(a); // Output: Stevie Ray
// // Console.WriteLine(b); // Output: Vaughn

void Split(string name, out string firstNames, out string _)
{
    int i = name.LastIndexOf(' ');
    firstNames = name.Substring(0, i);
    _ = name.Substring(i + 1);
}

// ---------------------------