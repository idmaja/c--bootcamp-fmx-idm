string? inputuser = Console.ReadLine();
long panjang = string.IsNullOrWhiteSpace(inputuser) || !long.TryParse(inputuser, out long hasil) ? 10 : hasil;

for (int i = 1; i < panjang + 1; i++)
{

    if (i % 3 == 0 && i % 5 == 0)
    {
        if (i % 7 == 0)
            Console.Write(", foobarjazz");
        else
            Console.Write(", foobar");
    }
    else if (i % 3 == 0)
    {
        if (i % 9 == 0)
            Console.Write(", huzz");
        else if (i % 7 == 0)
            Console.Write(", foojazz");
        else
            Console.Write(", foo");
    }
    else if (i % 4 == 0)
        Console.Write(", baz");
    else if (i % 5 == 0)
    {
        if (i % 7 == 0)
            Console.Write(", barjazz");
        else
            Console.Write(", bar");
    }
    else if (i % 7 == 0)
        Console.Write(", jazz");
    else if (i == 1)
        Console.Write(i.ToString() + "");
    else
        Console.Write(", " + i.ToString());
}

Console.ReadLine();
