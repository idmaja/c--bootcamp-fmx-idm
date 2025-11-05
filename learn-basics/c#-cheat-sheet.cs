// ---------- PROPERTY ----------
a.Length              // (int) Jumlah total elemen dalam array
a.LongLength          // (long) Jumlah elemen (versi 64-bit)
a.Rank                // (int) Jumlah dimensi array (1D, 2D, dst)
a.IsFixedSize         // (bool) True jika ukuran array tidak bisa diubah
a.IsReadOnly          // (bool) True jika array hanya bisa dibaca
a.IsSynchronized      // (bool) True jika aman untuk multi-thread
a.SyncRoot            // (object) Objek sinkronisasi untuk lock thread

// ---------- METHOD ----------
a.GetLength(dim)      // Mengembalikan jumlah elemen di dimensi ke-n
a.GetLongLength(dim)  // Versi 64-bit dari GetLength()
a.GetLowerBound(dim)  // Mengembalikan indeks awal dimensi ke-n (biasanya 0)
a.GetUpperBound(dim)  // Mengembalikan indeks akhir dimensi ke-n
a.GetValue(i)         // Mengambil nilai pada indeks i
a.SetValue(val, i)    // Mengubah nilai pada indeks i
a.Clone()             // Menghasilkan salinan (shallow copy) array
a.CopyTo(dest, idx)   // Menyalin isi array ke array lain mulai indeks tertentu

// ---------- STATIC METHOD (dipanggil via Array.) ----------
Array.Clear(a, start, len)   // Menghapus (set default) elemen dari array
Array.Copy(src, dest, len)   // Menyalin elemen antar array
Array.IndexOf(a, val)        // Mencari indeks pertama dari nilai tertentu
Array.LastIndexOf(a, val)    // Mencari indeks terakhir dari nilai tertentu
Array.Reverse(a)             // Membalik urutan elemen array
Array.Sort(a)                // Mengurutkan elemen array ascending
Array.Exists(a, cond)        // Mengecek apakah ada elemen yang memenuhi kondisi
Array.Find(a, cond)          // Mengambil elemen pertama yang memenuhi kondisi
Array.FindAll(a, cond)       // Mengambil semua elemen yang memenuhi kondisi
Array.FindIndex(a, cond)     // Mengambil indeks elemen pertama yang memenuhi kondisi
Array.ForEach(a, act)        // Menjalankan aksi pada tiap elemen (seperti foreach)
Array.TrueForAll(a, cond)    // Mengecek apakah semua elemen memenuhi kondisi
Array.Resize(ref a, newLen)  // Mengubah ukuran array (membuat array baru)

// ---------- LINQ EXTENSIONS (harus pakai using System.Linq;) ----------
a.Min()               // Mengambil nilai terkecil dari array numerik
a.Max()               // Mengambil nilai terbesar dari array numerik
a.Sum()               // Menjumlahkan semua elemen numerik
a.Average()           // Menghitung rata-rata
a.Distinct()          // Menghapus elemen duplikat
a.OrderBy(x => x)     // Mengurutkan ascending (hasilnya IEnumerable)
a.OrderByDescending(x => x) // Mengurutkan descending
a.Where(x => x > 5)   // Filter berdasarkan kondisi
a.First()             // Ambil elemen pertama
a.FirstOrDefault()    // Ambil elemen pertama, atau default jika kosong
a.Last()              // Ambil elemen terakhir
a.LastOrDefault()     // Ambil elemen terakhir, atau default jika kosong
a.ElementAt(2)        // Ambil elemen pada indeks ke-2
a.Contains(7)         // Cek apakah array mengandung nilai tertentu
a.All(x => x > 0)     // True jika semua elemen memenuhi kondisi
a.Any(x => x % 2 == 0)// True jika ada elemen yang memenuhi kondisi
a.Count(x => x > 5)   // Hitung jumlah elemen yang memenuhi kondisi
a.ToList()            // Ubah array menjadi List<T>
a.ToArray()           // Konversi kembali ke array (berguna setelah operasi LINQ)
a.Insert(0, 99)      // Menyisipkan elemen (untuk List<T>, bukan array langsung)
a.InsertAt(0, 99)   // Menyisipkan elemen pada indeks tertentu (untuk List<T>)
a.RemoveAt(0)       // Menghapus elemen pada indeks tertentu (untuk List<T>)

// ---------- CONTOH TAMBAHAN ----------
int[] a = { 1, 3, 5, 7, 9 };
Console.WriteLine(a.Length);         // 5
Console.WriteLine(a.Rank);           // 1
Console.WriteLine(a.Max());          // 9
Console.WriteLine(a.Min());          // 1
Console.WriteLine(a.Sum());          // 25
Console.WriteLine(a.Average());      // 5
Array.Reverse(a);                    // Urutannya jadi: 9,7,5,3,1
