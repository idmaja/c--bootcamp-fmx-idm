int angka1 = 2, angka2 = 4;

// Util.Tukar<int>(ref angka1, ref angka2); // explicit
Util.Tukar(ref angka1, ref angka2); // implicit, begini juga bisa

Console.WriteLine($"angka pertama : {angka1}; angka kedua : {angka2}");

Console.WriteLine("--------------------------------------");
Console.WriteLine();

// Kotak untuk angka
var kotakAngka = new Kotak<int>();
kotakAngka.Simpan(123);
Console.WriteLine(kotakAngka.Ambil()); // Output: 123

// Kotak untuk teks
var kotakTeks = new Kotak<string>();
kotakTeks.Simpan("Halo Dunia");
Console.WriteLine(kotakTeks.Ambil()); // Output: Halo Dunia

// Kotak untuk tanggal
var kotakTanggal = new Kotak<DateTime>();
kotakTanggal.Simpan(DateTime.Now);
Console.WriteLine(kotakTanggal.Ambil()); // Output: waktu sekarang

Console.WriteLine("--------------------------------------");
Console.WriteLine();

var gudangInt = new Gudang<int>();
gudangInt.Simpan(10);
gudangInt.Simpan(20);
Console.WriteLine(gudangInt.AmbilTerakhir()); // Output: 20

var gudangString = new Gudang<string>();
gudangString.Simpan("Apel");
gudangString.Simpan("Jeruk");
Console.WriteLine(gudangString.AmbilTerakhir()); // Output: Jeruk

// Memanggil method generik
Gudang<int>.CetakIsi("Tes"); // Output: Isi: Tes

int[] angkas = { 10, 12, 14, 15, 20, 21 };
foreach (int item in angkas)
{    
    Gudang<int>.CetakIsi(item);
}

Console.WriteLine("--------------------------------------");
Console.WriteLine();
