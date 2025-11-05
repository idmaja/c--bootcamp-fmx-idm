static bool Hitung(int aku, out int x)
{
    x = 5;
    x *= aku;
    return true;
}

int a = 5;
Console.WriteLine(a);
if (Hitung(4, out int x))
{
    Console.WriteLine(x); 
}