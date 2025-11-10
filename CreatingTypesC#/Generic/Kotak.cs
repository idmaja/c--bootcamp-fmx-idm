public class Kotak<T> // T = placeholder tipe data
{
    private T isi;

    public void Simpan(T value)
    {
        isi = value;
    }

    public T Ambil()
    {
        return isi;
    }
}