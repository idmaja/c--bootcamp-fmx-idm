int n = int.Parse(Console.ReadLine());
for (int i = 1; i < n + 1; i++){
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.Write(", foobar");
    }
    else if (i % 3 == 0)
    {
        Console.Write(", bar");
    }
    else if (i % 5 == 0)
    {
        Console.Write(", bar");
    }
    else if (i == 1)
    {
        Console.Write(i + "");
    }
    else
    {
        Console.Write(", " + i);
    }
}
