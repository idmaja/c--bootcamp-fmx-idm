Console.Write("Masukkan Angka: ");
int angkaInput = Convert.ToInt32(Console.ReadLine());
if (angkaInput % 2 == 0)
    Console.WriteLine("Angka {0} adalah Genap", angkaInput);
else
    Console.WriteLine("Angka {0} adalah Ganjil", angkaInput);


/// ------------------------------------------------------------------------------


Console.WriteLine("\nBob's Big Giveaway");
Console.Write("Pilih sebuah pintu: 1, 2, atau 3 : ");
string? pintu = Console.ReadLine();

string message = (pintu == "1") ? "Hadiah di balik pintu 1 adalah Mobil!" :
                 (pintu == "2") ? "Hadiah di balik pintu 2 adalah Liburan!" :
                 (pintu == "3") ? "Hadiah di balik pintu 3 adalah Uang!" :
                 "Maaf, pilihan Anda tidak valid.";
Console.WriteLine(message);