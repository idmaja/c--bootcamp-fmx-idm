static int Faktorial(int n)
{
    if (n == 0 || n == 1)
    {
        return 1;
    }
    else
    {
        return n * Faktorial(n - 1);
    }
}

int n = 8;
Console.WriteLine("Faktorial dari {0}! adalah {1} ", n, Faktorial(n));