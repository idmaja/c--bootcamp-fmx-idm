
public enum StoreStatus
{
    Open = 1,
    Closed = 0
}

public class Store
{
    private string? _address;
    private string? _name;
    private string? _phone;
    private static int _storeCount = 0;
    private readonly DateTime _dateCreated = DateTime.Now;

    public StoreStatus Status { get; set; }
    public static int StoreCount => _storeCount;
    // public string Status;
    public string? Address
    {
        get { return _address; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Address cannot be empty!");
            _address = value;
        }
    }
    public string? Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty!");
            _name = value;
        }
    }
    public string? Phone
    {
        get { return _phone; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Phone cannot be empty!");
            _phone = value;
        }
    }

    public Store()
    {
        Console.WriteLine("Store created!");
        Status = StoreStatus.Closed;
        _storeCount++;
    }

    public Store(string name, string address, string phone)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Address = address;
        Phone = phone;
        Status = StoreStatus.Closed;
        _storeCount++;
    }


    public void Open()
    {
        Status = StoreStatus.Open;
        // Console.WriteLine("Store is open!");
    }

    public void Close()
    {
        Status = StoreStatus.Closed;
        // Console.WriteLine("Store is closed!");
    }

    public void PrintStoreInfo()
    {
        Console.WriteLine($"Store Name: {Name}");
        Console.WriteLine($"Store Address: {Address}");
        Console.WriteLine($"Store Phone: {Phone}");
        Console.WriteLine($"Store Status: {Status}");
        Console.WriteLine($"Store Created: {_dateCreated}");
    }

    public static int PrintStoreCount()
    {
        return StoreCount;
    }


}