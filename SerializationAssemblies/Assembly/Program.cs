// Nama File: AplikasiSaya.exe
// Project Type: Console Application

Console.WriteLine("Aplikasi Kalkulator Dimulai...");

// Menggunakan class dari DLL
OperasiMatematika otak = new OperasiMatematika();

int hasil = otak.Tambah(10, 5);

Console.WriteLine("Hasil 10 + 5 adalah: " + hasil);
Console.ReadKey();