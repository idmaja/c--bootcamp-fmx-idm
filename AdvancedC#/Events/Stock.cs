public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);

public delegate T NameChangedHandler<T>(T oldName, T newName);

public class Stock
{
    private decimal price;
    private string? nama;

    public event PriceChangedHandler? PriceChanged;

    public event NameChangedHandler<string>? NameChanged;

    public decimal Price
    {
        get => price;
        set
        {
            if (price == value) return;

            decimal oldPrice = price;
            price = value;

            PriceChanged?.Invoke(oldPrice, price); // panggil event jika ada subscriber
        }
    }

    public string? Nama
    {
        get => nama;
        set
        {
            if (nama == value) return;

            string? oldName = nama ?? "NOBODY";
            nama = value;

            NameChanged?.Invoke(oldName!, nama!);
        }
    }

    public static void Stock_PriceChanged(decimal oldPrice, decimal newPrice)
    {
        Console.WriteLine($"Price changed from {oldPrice} to {newPrice}");
    }
    public static void Stock_PriceChanged_2(decimal oldPrice, decimal newPrice)
    {
        Console.WriteLine($"Price changed from {oldPrice} to {newPrice} (2)");
    }

    public static T Stock_NameChanged<T>(T oldName, T newName)
    {
        Console.WriteLine($"Name changed from {oldName} to {newName}");
        return newName;
    }
 }


