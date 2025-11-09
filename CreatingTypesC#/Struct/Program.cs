Span<byte> bufferSpan = stackalloc byte[2]; // stackalloc di sini
var buffer = new MyBuffer(bufferSpan);      // span dikirim ke struct

buffer.Fill(200);
buffer.Print();

PaintStore store = new PaintStore();

// Menambahkan beberapa warna ke daftar Colors
store.Colors.Add(new Color { ColorName = "Red",   Red = 255, Green = 0,   Blue = 0 });
store.Colors.Add(new Color { ColorName = "Green", Red = 0,   Green = 255, Blue = 0 });
store.Colors.Add(new Color { ColorName = "Blue",  Red = 0,   Green = 0,   Blue = 255 });
store.Colors.Add(new Color { ColorName = "Yellow",Red = 255, Green = 255, Blue = 0 });

// Menampilkan semua warna menggunakan metode statis
PaintStore.ColorsInfo(store);



ref struct MyBuffer  // ref struct (artinya tidak bisa di heap mau ditaruh dimanapun itu karena sudah ada proteksi 'ref')
{
    private Span<byte> data;

    public MyBuffer(Span<byte> data)
    {
        this.data = data;
    }

    public void Fill(byte value)
    {
        for (int i = 0; i < data.Length; i++)
            data[i] = value;
    }

    public void Print()
    {
        foreach (var b in data)
            Console.Write(b + " ");
        Console.WriteLine();
    }
}

// regular struct
public struct Color
{
    public string? ColorName { get; set; }
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
}

public class PaintStore
{
    private List<Color>? _colors;

    public List<Color> Colors
    {
        get
        {
            if (_colors == null)
                _colors = new List<Color>();
            return _colors;
        }
        set
        {
            _colors = value;
        }
    }

    public PaintStore()
    {
        Console.WriteLine("Base Constructor sudah berjalan!");
    }


    public static void ColorsInfo(PaintStore store)
    {
        Console.WriteLine("ColorsInfo sudah berjalan!");
        foreach (var color in store.Colors)
        {
            Console.WriteLine($"{color.ColorName} = {color.Red} + {color.Green} + {color.Blue}");
        }
    }

}