int[] angka = { 0, 1, 2, 3, 4 };

for (int i = 0; i < angka.Length; i++)
{
    if (i == angka.Length - 1)
    {
        Console.Write(angka[i]);
    } else
    {
        Console.Write(angka[i] + " + ");
    }
}

double jumlah = 0;

foreach (int a in angka)
{
    jumlah += a;
}

Console.Write(" = " + jumlah);
Console.WriteLine();

// Console.WriteLine(angka.LongLength); // tipe data LONG

// Console.WriteLine("Panjang angka: " + angka.Length); // tipe data INT

/// ------------------------------------------------------------------------------


// int[] numbers = new int[5];
// numbers[0] = 10;
// numbers[1] = 12;
// numbers[2] = 20;

// int[] numbers = new int[] { 10, 12, 20, 25, 30 };

// string[] nama = new string[] { "Andi", "Budi", "Caca" };

// for (int items = 0; items < nama.Length; items++)
// {
//     Console.Write(nama[items]);
// }

// foreach (string item in nama)
// {
//     Console.Write(item + " ");
// }


/// ------------------------------------------------------------------------------

string message = "Hello World from C# Arrays";

char[] charMessage = message.ToCharArray();
// Array.Reverse(charArray);

foreach (char c in charMessage) Console.Write(c + "-");

Console.WriteLine("\n charMessage : " + new string(charMessage));