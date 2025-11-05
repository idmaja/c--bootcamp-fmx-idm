static string CetakAngka(int angka)
{
    return "Angkanya adalah " + angka;
}

Console.WriteLine("Masukkan Angka: ");
int angkaInput = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(CetakAngka(angkaInput));