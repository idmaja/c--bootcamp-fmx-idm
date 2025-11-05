namespace CobaProjectConsoleCSharp1
{
    class Mobil
    {
        public string? warna; //? menandakan bahwa variabel ini boleh bernilai null tapi konsekuensinya harus siap handle null saat pakai.
        public int kecepatan = 0;
        protected string merk = ""; 
        internal string tipe = "";
        private int harga = 50000;

        // Constructor
        public Mobil(string warnaInput, string merkInput, string tipeInput, int kecepatanInput)
        {
            warna = warnaInput;
            merk = merkInput;
            tipe = tipeInput;
            kecepatan = kecepatanInput;
            Console.WriteLine("Mobil dibuat dengan constructor!");
        }

        public string GetMerk()
        {
            return merk ?? "";
        }

        public void Klakson()
        {
            Console.WriteLine("Tinnn Tinnn!" + " Harga Mobil: " + harga);
        }
    }
}