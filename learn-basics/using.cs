using (StreamWriter writer = new StreamWriter("contoh.txt"))
{
    writer.WriteLine("Halo");
    writer.WriteLine("Ini contoh using");
} // StreamWriter ditutup otomatis di sini

Console.WriteLine("Selesai");
