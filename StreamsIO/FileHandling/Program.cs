string path = @"catatan_rahasia.txt";
string pathBackup = @"catatan_rahasia_v2.txt";

// --- MENGECEK FILE ---
if (File.Exists(path))
{
    Console.WriteLine("File lama ditemukan, akan dihapus dulu...");
    File.Delete(path);
}

// --- MEMBUAT & MENULIS FILE (manual dengan FileStream) ---
Console.WriteLine("Sedang membuat file baru...");

using (FileStream fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write))
{
    using (StreamWriter sw = new StreamWriter(fs))
    {
        sw.WriteLine("Baris 1: Ini adalah rahasia.");
        sw.WriteLine("Baris 2: Belajar C#.");
        sw.Write("Baris 3: Tulisan ini tanpa enter.");
    } 
}

// --- MEMBACA FILE (dengan File Class) ---
Console.WriteLine("\n--- Membaca Isi File (Cara Cepat) ---");

string[] semuaBaris = File.ReadAllLines(path);

foreach (string baris in semuaBaris)
    Console.WriteLine("Baca: " + baris);

Console.WriteLine("\nSedang menyalin file...");
// Copy file ke nama baru 
File.Copy(path, pathBackup, true); // true artinya overwrite jika ada

if(File.Exists(pathBackup))
    Console.WriteLine("Backup berhasil dibuat: " + pathBackup);
else    
    Console.WriteLine("Backup gagal dibuat.");

Console.ReadKey();