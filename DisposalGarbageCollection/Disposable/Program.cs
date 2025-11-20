DemoFile demoFile = new DemoFile("demoSimpleDispose.txt");

// ----- using statement ---------
using (var fs = new FileStream("demo.txt", FileMode.Open))
{
    // pakai fs
} // di sini fs.Dispose() otomatis terpanggil


