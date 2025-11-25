await Main();


async Task<int> MasakMieAsync()
{
    Console.WriteLine("1. Mulai rebus air...");
    
    // Task.Delay adalah versi async dari Thread.Sleep
    await Task.Delay(3000); 

    Console.WriteLine("2. Air mendidih, masukkan mie...");
    await Task.Delay(2000);

    Console.WriteLine("3. Mie matang!");
    return 100;
}

// Cara pakainya:
async Task Main()
{
    Console.WriteLine("Pesan Mie...");
    int nilai = await MasakMieAsync();
    Console.WriteLine("Selesai makan. Nilai rasa: " + nilai);
}



/// ----- PROGRESS ------
var pelapor = new Progress<int>(persen => {
    Console.WriteLine($"Loading... {persen}%"); // Aman update UI di sini
});
await CopyFileAsync(pelapor);

async Task CopyFileAsync(IProgress<int> laporan)
{
    for (int i = 0; i <= 100; i+=10)
    {
        await Task.Delay(500);
        laporan.Report(i); 
    }
}
