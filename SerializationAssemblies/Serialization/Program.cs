using System.Text.Json;

// --- SERIALIZATION ---
Tutorial tutorial = new Tutorial
{
    ID = 1,
    Name = "Belajar .NET C# (JSON)"
};

// Opsi JSON, supaya rapi dan mudah dibaca, diberi indent
var options = new JsonSerializerOptions{ WriteIndented = true, AllowTrailingCommas = true };

// Ubah object ke string JSON
string jsonString = JsonSerializer.Serialize(tutorial, options);

// Simpan ke file
string path = "DataTutorial.json";
File.WriteAllText(path, jsonString);

Console.WriteLine("Data berhasil disimpan ke " + path);

// --- DESERIALIZATION ---
// Baca isi file JSON
string jsonFromFile = File.ReadAllText(path);

// Ubah JSON jadi object Tutorial lagi
Tutorial tutorial2 = JsonSerializer.Deserialize<Tutorial>(jsonFromFile)!;

// Buktikan datanya
Console.WriteLine("\n--- Data Hasil Baca ---");
Console.WriteLine("ID: " + tutorial2.ID);
Console.WriteLine("Nama: " + tutorial2.Name);

Console.ReadKey();