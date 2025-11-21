
/// <summary>
/// Misalkan  punya aplikasi yang memuat Foto Beresolusi Tinggi (100MB).
/// Jika pakai Strong Reference: 
/// - Foto itu akan diam di memori selamanya. Kalau buka 10 foto, RAM habis -> Error.
/// Jika pakai Weak Reference: Foto disimpan di cache.
/// - Jika memori masih lega, foto tetap di situ. Saat user mau lihat lagi, langsung muncul (cepat).
/// - Jika memori penuh, GC akan membuang foto itu. Saat user mau lihat lagi, aplikasi download ulang.
/// - *Benefit: Aplikasi tidak crash karena kehabisan memori, tapi tetap cepat kalau memori cukup .
/// </summary>
class FotoCache
{
    private WeakReference _fotoRef;

    public byte[] GetFoto()
    {
        var foto = _fotoRef?.Target as byte[];

        if (foto != null)
        {
            return foto; // Masih ada di memori
        }

        foto = LoadFotoDariDisk(); // Buat baru
        _fotoRef = new WeakReference(foto);
        return foto;
    }

    private byte[] LoadFotoDariDisk()
    {
        return File.ReadAllBytes("gambar.png");
    }
}