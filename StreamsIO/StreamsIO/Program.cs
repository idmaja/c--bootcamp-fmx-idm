string path = @"latihan-stream.txt";

// --- MENULIS DATA (WRITE) ---
// Kita pakai FileStream sebagai 'Pipa' ke harddisk
// FileMode.Create: Buat file baru atau timpa yang lama
// FileAccess.Write: Kita cuma mau nulis
using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
{
    // Kita pasang 'Keran' StreamWriter agar bisa nulis teks, bukan byte
    using (StreamWriter writer = new StreamWriter(fs))
    {
        writer.WriteLine("Halo!");
        writer.WriteLine("Ini adalah contoh penggunaan Stream.");
        writer.Write("Stream itu seperti air yang mengalir.");
    }
}

Console.WriteLine("Data berhasil ditulis ke file.");

// --- MEMBACA DATA (READ) ---
using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
{
    // Pasang 'Keran' StreamReader untuk menerjemahkan byte jadi teks
    using (StreamReader reader = new StreamReader(fs))
    {
        // Baca semua isi dari awal sampai habis
        string isiFile = reader.ReadToEnd();
        
        Console.WriteLine("\n--- Isi File ---");
        Console.WriteLine(isiFile);
    }
}

// Contoh sederhananya File Class (shortcut tanpa buat Stream manual)
// File.WriteAllText(path, "Isi baru menimpa yang lama");