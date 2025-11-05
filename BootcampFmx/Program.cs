// string a;
// Split("Stevie Ray Vaughan", out a, out _);
// Console.WriteLine(a); // Output: Stevie Ray
// // Console.WriteLine(b); // Output: Vaughn

// void Split(string name, out string firstNames, out string _)
// {
//     int i = name.LastIndexOf(' ');
//     firstNames = name.Substring(0, i);
//     _ = name.Substring(i + 1);
// }

// ---------------------------


/// VARIABLES AND DATA TYPES IN C#
// int x = 42;

// double y = 3.14;

// char[] z = new Char[2];
// z[0] = 'A';
// z[1] = 'B';

// string hai = "Hello, World!";

// bool cond = true;

// Console.WriteLine(x);
// Console.WriteLine(y);
// Console.WriteLine(z[0] + z[1]);
// Console.WriteLine(hai);
// Console.WriteLine(cond);











/// ------------------------------------------------------------------------------

/// USER INPUT

// Console.WriteLine("Angka 1: ");
// int angka1 = Convert.ToInt32(Console.ReadLine());
// Console.WriteLine("Angka 2: ");
// int angka2 = Convert.ToInt32(Console.ReadLine());
// Console.WriteLine("Hasil Penjumlahan: " + Convert.ToDouble(angka1) / Convert.ToDouble(angka2));

// Console.ReadLine();









/// ------------------------------------------------------------------------------

/// CONSTANTS

// const double PHI = 3.14;
// const int S = 5;
// double luas = PHI * S * S;
// Console.WriteLine("Luas Lingkaran: " + luas);










/// ------------------------------------------------------------------------------

/// WHILE LOOP

// int counter = 1;

// while (counter <= 10) 
// {
//     Console.WriteLine("Perulangan ke-" + counter);
//     counter++;
// }
// Console.WriteLine("Selesai");










/// ------------------------------------------------------------------------------

/// FOR LOOP

// int jumlah = 1;
// for (int counter = 1; counter <= 10; ++counter)
// {
//     Console.WriteLine("Perulangan ke-" + counter);
//     if (counter == 5)
//     {
//         continue;
//     }

//     jumlah *= counter;
// }

// Console.WriteLine("Jumlah: " + jumlah);
// Console.WriteLine("Selesai");








/// ------------------------------------------------------------------------------

/// METHOD


// static string CetakAngka(int angka)
// {
//     return "Angkanya adalah " + angka;
// }

// Console.WriteLine("Masukkan Angka: ");
// int angkaInput = Convert.ToInt32(Console.ReadLine());
// Console.WriteLine(CetakAngka(angkaInput));



// static double Luas(double panjang = 10, double lebar = 5)
// {
//     return panjang * lebar;
// }

// double LuasPersegiPanjang = Luas(lebar:2.4, panjang:3.5);

// Console.WriteLine("Luas Persegi Panjang: " + LuasPersegiPanjang);



// static bool Hitung(int aku, out int x)
// {
//     x = 5;
//     x *= aku;
//     return true;
// }

// int a = 5;
// Console.WriteLine(a);
// if (Hitung(4, out int x))
// {
//     Console.WriteLine(x); 
// }












/// ------------------------------------------------------------------------------

/// METHOD OVERLOADING


// static int Faktorial(int n)
// {
//     if (n == 0 || n == 1)
//     {
//         return 1;
//     }
//     else
//     {
//         return n * Faktorial(n - 1);
//     }
// }

// int n = 8;
// Console.WriteLine("Faktorial dari {0}! adalah {1} ", n, Faktorial(n));













/// ------------------------------------------------------------------------------

/// ARRAYS

// int[] angka = { 0, 1, 2, 3, 4 };

// for (int i = 0; i < angka.Length; i++)
// {
//     if (i == angka.Length - 1)
//     {
//         Console.Write(angka[i]);
//     } else
//     {
//         Console.Write(angka[i] + " + ");
//     }
// }

// double jumlah = 0;

// foreach (int a in angka)
// {
//     jumlah += a;
// }

// Console.Write(" = " + jumlah);

// Console.WriteLine(angka.LongLength);
// Console.WriteLine(angka.Length);
















/// ------------------------------------------------------------------------------

/// ARRAYS MULTIDIMENSIONAL


// int[,] angka = { 
//     { 1, 2, 3 }, { 4, 5, 6 } 
// };

// int[,,] angka2 = { 
//     { 
//         { 1, 2, 3 }, { 4, 5, 6 } 
//     }, 
//     { 
//         { 7, 8, 9 }, { 10, 11, 12 } 
//     } 
// };

// for (int i = 0; i < angka.GetLength(0); i++)
// {
//     for (int j = 0; j < angka.GetLength(1); j++)
//     {
//         Console.Write(angka[i, j] + " ");
//     }
//     Console.WriteLine();
// } 

// Console.WriteLine(angka2[1, 0, 2]);

// Console.WriteLine(angka2.GetLength(2));
// Console.WriteLine(angka2.Length);










/// ------------------------------------------------------------------------------

/// STRING ARRAYS



// string nama = "Apa \"aku\" adalah"; // untuk menambahkan tanda petik di dalam string
// string nama = "Apa aku \n adalah";
// string nama = "Kamu harus pergi ke drive c:\\"; // untuk menghindari error pada backslash
// string nama = @"Kamu harus pergi ke drive c:\"; // cara lain untuk menghindari error pada backslash

// string nama = String.Format("{1} = {0}", "Satu", "Dua");

// string nama = String.Format("{0:C}", 1500000); // untuk menambahkan simbol mata uang

// string nama = String.Format("{0:N}", 123456); // untuk menambahkan koma setiap 3 digit

// string nama = String.Format("{0:P}", .12); // untuk menjadikan persen

// string nama = String.Format("Phone Number : {0 : (###) ####-####-####}", 62895380222584); // untuk format phone number dan # untuk digit angka

// string nama = " hallooo teman-teman ";
// nama = nama.Substring(6);
// nama = nama.ToUpper();
// nama = nama.Replace("TEMAN-TEMAN", "SAHABAT");
// nama = nama.Remove(6, 8);
// nama = nama.Trim().Length.ToString();
// nama = nama.Length.ToString();

// Console.WriteLine(nama);

// nama = nama.Remove(3, 1);
// Console.WriteLine(nama);
// nama = nama.Insert(3, " asdasd");
// Console.WriteLine(nama);
// nama = nama.Replace("asdasd", "B");
// Console.WriteLine(nama);
// nama = nama.ToUpper();
// Console.WriteLine(nama);

// if(nama.Contains("B"))
// {
//     nama = nama.Replace("B", "b");
// }

// Console.WriteLine(nama);








/// ------------------------------------------------------------------------------

/// CLASSES AND OBJECTS

// namespace CobaProjectConsoleCSharp1
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Manusia andy = new Manusia();
//             andy.Nama = "Andy";
//             andy.Umur = 20;
//             andy.PerkenalkanDiri();

//             Manusia budi = new Manusia();
//             budi.Nama = "Budi";
//             budi.Umur = 22;
//             budi.PerkenalkanDiri();

//             Console.Write("Siapa nama dari manusia andy : {0} \n", andy.Nama);
//         }
//     }
// }






/// ------------------------------------------------------------------------------

/// CLASSES ENCAPSULATION

// namespace CobaProjectConsoleCSharp1
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Mobil toyota = new Mobil();
//             toyota.warna = "Abu";
//             string merk = toyota.GetMerk("Toyota");
//             toyota.tipe = "SUV";
//             toyota.kecepatan = 200;
//             toyota.Klakson();

//             Console.WriteLine("Warna Mobil: " + toyota.warna);
//             Console.WriteLine("Merk Mobil: " + merk);
//             Console.WriteLine("Tipe Mobil: " + toyota.tipe);
//             Console.WriteLine("Kecepatan Mobil: " + toyota.kecepatan + " km/h");
//         }
//     }
// }








/// ------------------------------------------------------------------------------

/// CLASSES CONSTRUCTOR AND DESTRUCTOR

// namespace CobaProjectConsoleCSharp1
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Mobil toyota = new Mobil("Abu", "Toyota", "SUV", 200);
//             toyota.Klakson();

//             Console.WriteLine("Warna Mobil: " + toyota.warna);
//             Console.WriteLine("Merk Mobil: " + toyota.GetMerk());
//             Console.WriteLine("Tipe Mobil: " + toyota.tipe);
//             Console.WriteLine("Kecepatan Mobil: " + toyota.kecepatan + " km/h");

//             Manusia andy = new Manusia();
//             andy.nama = "Andy";
//             andy.umur = 20;
//             andy.PerkenalkanDiri();
//         }
//     }
// }









/// ------------------------------------------------------------------------------

/// DATE AND TIMES

// DateTime sekarang = DateTime.Now;
// Console.WriteLine("Sekarang: " + sekarang.ToString());
// Console.WriteLine("Sekarang: " + sekarang.ToString("yyyy-MM-dd HH:mm:ss"));
// Console.WriteLine("Sekarang: " + sekarang.ToShortDateString());
// Console.WriteLine("Sekarang: " + sekarang.ToShortTimeString());
// Console.WriteLine("Sekarang: " + sekarang.ToLongDateString());
// Console.WriteLine("Sekarang: " + sekarang.ToLongTimeString());

// Console.WriteLine(sekarang.AddDays(-2000).ToLongDateString());

// Console.WriteLine(sekarang.Month);

// DateTime tanggalLahir = new DateTime(1995, 5, 17);
// Console.WriteLine("Tanggal Lahir: " + tanggalLahir.ToLongDateString());

// DateTime ulangTahun = DateTime.Parse("2024-05-17");
// Console.WriteLine("Ulang Tahun: " + ulangTahun.ToLongDateString());

// TimeSpan umurku = DateTime.Now.Subtract(tanggalLahir);
// Console.WriteLine("Umurku dalam hari: " + umurku.TotalDays + " hari");










/// ------------------------------------------------------------------------------

/// IF STATEMENTS


Console.Write("Masukkan Angka: ");
int angkaInput = Convert.ToInt32(Console.ReadLine());
if (angkaInput % 2 == 0)
    Console.WriteLine("Angka {0} adalah Genap", angkaInput);
else
    Console.WriteLine("Angka {0} adalah Ganjil", angkaInput);

Console.WriteLine("\nBob's Big Giveaway");
Console.Write("Pilih sebuah pintu: 1, 2, atau 3 : ");
string? pintu = Console.ReadLine();

string message = (pintu == "1") ? "Hadiah di balik pintu 1 adalah Mobil!" :
                 (pintu == "2") ? "Hadiah di balik pintu 2 adalah Liburan!" :
                 (pintu == "3") ? "Hadiah di balik pintu 3 adalah Uang!" :
                 "Maaf, pilihan Anda tidak valid.";
Console.WriteLine(message);
Console.ReadLine();