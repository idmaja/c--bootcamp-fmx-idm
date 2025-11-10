string? inputuser = Console.ReadLine();
int panjang = string.IsNullOrWhiteSpace(inputuser) || !int.TryParse(inputuser, out int hasil) ? 10 : hasil;

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
        if (i % 7 == 0)
            Console.Write(", foojazz");
        else
            Console.Write(", foo");
    }
    else if (i % 5 == 0)
    {
        if (i % 7 == 0)
            Console.Write(", barjazz");
        else
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

Console.ReadLine();
