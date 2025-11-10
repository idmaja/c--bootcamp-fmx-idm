public class Gudang<T>
{
    private T[] data = new T[5];
    private int index = 0;

    public void Simpan(T item)
    {
        data[index++] = item;
    }

    public T AmbilTerakhir()
    {
        return data[--index];
    }

    public static void CetakIsi<U>(U item)
    {
        Console.WriteLine($"Isi: {item}");
    }
}