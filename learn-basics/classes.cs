class Manusia
{
    public string Nama;

    public int Umur;

    // Method untuk memperkenalkan diri
    public void PerkenalkanDiri()
    {
        Console.WriteLine($"Halo, nama saya {Nama} dan saya berumur {Umur} tahun.");
    }
}


class Mobil
{
    public string warna;

    public int kecepatan;

    protected string merk;

    internal string tipe;

    private int _harga = 50000;

    public string GetMerk(string merkInput)
    {
        return merk = merkInput;
    }

    public void Klakson()
    {
        Console.WriteLine("Tinnn Tinnn!" + " Harga Mobil: " + _harga);
    }
}



/// ------------------------------------------------------------------------------

/// CLASSES AND OBJECTS

// namespace CobaProjectConsoleCSharp1
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
                Manusia andy = new Manusia();
                andy.Nama = "Andy";
                andy.Umur = 20;
                // andy.PerkenalkanDiri();

                Manusia budi = new Manusia();
                budi.Nama = "Budi";
                budi.Umur = 22;
                // budi.PerkenalkanDiri();

                Manusia cici = null;
                // Console.WriteLine(cici?.Nama); // Safe navigation operator to avoid null reference exception

                Console.Write($"Siapa nama dari manusia budi : {budi.Nama} \n");
                Console.Write("Siapa nama dari manusia andy : {0} \n", andy.Nama);
                Console.Write("Siapa nama dari manusia cici : {0} \n", cici?.Nama);
                
                Console.ReadKey();
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