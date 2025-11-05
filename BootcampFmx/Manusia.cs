namespace CobaProjectConsoleCSharp1
{
    class Manusia
    {
        //? menandakan bahwa variabel ini boleh bernilai null tapi konsekuensinya harus siap handle null saat pakai.
        // public string nama = "";
        // public int umur = 0;

        // // GETTER SETTER
        // public int Umur
        // {
        //     get { if (umur > 25) return umur; else return 15; }
        //     set { if (value > 25) umur = value; }
        // }

        public string nama { get; set; } = "";
        public int umur { get; set; }

        public void PerkenalkanDiri()
        {
            Console.WriteLine($"Halo, nama saya {nama} dan saya berumur {umur} tahun.");
        }
    }
}