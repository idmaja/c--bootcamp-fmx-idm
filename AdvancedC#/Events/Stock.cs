public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);

public delegate T NameChangedHandler<T>(T oldName, T newName);

public class Stock
{
    private decimal _price;
    private string? _nama;

    public event PriceChangedHandler? PriceChanged;

    public event NameChangedHandler<string>? NameChanged;

    public decimal Price
    {
        get => _price;
        set
        {
            if (_price == value) return;

            decimal oldPrice = _price;
            _price = value;

            PriceChanged?.Invoke(oldPrice, _price); // panggil event jika ada subscriber
        }
    }

    public string? Nama
    {
        get => _nama;
        set
        {
            if (_nama == value) return;

            string? oldName = _nama ?? "NOBODY";
            _nama = value;

            NameChanged?.Invoke(oldName!, _nama!);
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


