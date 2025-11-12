Console.WriteLine("-----------------------------");
Console.WriteLine();

IEnumerable<int> CountToThree()
{
    Console.WriteLine("Mulai hitung");
    yield return 1;

    Console.WriteLine("Lanjut ke dua");
    yield return 2;

    Console.WriteLine("Lanjut ke tiga");
    yield return 3;
}

foreach (int n in CountToThree())
{
    Console.WriteLine($"Output: {n}");
}

Console.WriteLine("-----------------------------");
Console.WriteLine();

string filePath = "log.txt";

// Membaca baris satu per satu tanpa memuat semua ke memori
foreach (string line in LogReader.ReadLogLines(filePath))
{
    if (line.Contains("ERROR"))
    {
        Console.WriteLine($"[!] Error found: \"{line}\"");
    }
}

Console.WriteLine("Done scanning log file.");
Console.WriteLine("-----------------------------");
Console.WriteLine();