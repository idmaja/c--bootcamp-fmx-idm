public class Locking
{
    static readonly object kunciGudang = new object(); // Objek khusus untuk kunci [cite: 68]
    static int stok = 0;

    public static void TambahBarang()
    {
        // Hanya satu thread yang boleh masuk blok ini di satu waktu
        lock (kunciGudang) 
        {
            stok++;
            Console.WriteLine("Barang ditambah. Total: " + stok);
        } // Kunci otomatis dikembalikan di sini
    }

    // CONTOH BERBAHAYA (Tanpa Pengaman)
    // int stokBahan = 0; // Shared data
    // void TambahStok() 
    // {
    //     stokBahan++; // Ini NON-ATOMIC, bisa konflik jika diakses barengan [cite: 66]
    // }
}