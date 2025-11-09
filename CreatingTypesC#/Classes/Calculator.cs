
/// <summary>
/// Access modifier + static + parameter biasa, ref, out
/// </summary>

public class Calculator
{
    // public + static + parameter biasa
    public static int Add(int a, int b)
    {
        return a + b;
    }

    // internal + parameter ref
    internal void Increment(ref int value)
    {
        value += value;
    }

    // private + parameter out
    private bool TryParsePositive(string text, out int result)
    {
        if (int.TryParse(text, out result) && result > 0)
        {
            return true;
        }

        result = 0;
        return false;
    }

    // protected + parameter biasa
    protected void PrintInfo(string label, decimal price)
    {
        Console.WriteLine($"{label}: {price}");
    }

    // Contoh pemanggilan dari dalam class itu sendiri
    public void DemoInternalMethods()
    {
        int number = 5;
        Increment(ref number); 

        int parsed;
        bool ok = TryParsePositive("10", out parsed); 

        Console.WriteLine($"After increment: {number}");
        Console.WriteLine($"Parse ok: {ok}, value: {parsed}");
    }
}