int? umur = null;

Console.Write("Masukkan umur (boleh kosong): ");
string? input = Console.ReadLine();

// umur = int.TryParse(input, out int hasil) && hasil < int.MaxValue ? hasil : int.MaxValue - 1;

if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("1");
    // umur = int.TryParse(input, out int hasil); // kalau diisi, ubah jadi angka
    if (!int.TryParse(input, out int hasil) && hasil > int.MaxValue)
        umur = int.MaxValue - 1;
    else
        umur = int.Parse(input);
}


Console.WriteLine($"Umur pengguna: {umur?.ToString() ?? "Belum diisi"}");
