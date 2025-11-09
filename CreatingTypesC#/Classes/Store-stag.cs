public interface IStore
{

    void OpenStore();
    void CloseStore();
    bool IsOpen();
    void AddProduct(Product product);
    void RemoveProduct(int productId);
    void PrintInventory();
    int GetTotalInventoryValue();
}

public enum StoreStatuses
{
    Open = 1,
    Closed = 0,
}

public struct Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Price { get; set; }
}

public class Stores : IStore
{
    // --- DATA STATIC ---
    // 's_storeCounter' adalah SATU variabel yang dibagikan oleh SEMUA toko.
    private static int s_storeCounter = 0;

    // --- Data Instance (Non-Static) ---
    private readonly DateTime _buildDate;
    public readonly Guid Id;
    public string Name { get; set; }
    public StoreStatus Status { get; private set; } 
    public List<Product> Products { get; private set; }
    public string Address { get; set; }

    public DateTime BuildDate => _buildDate;
    
    // Konstruktor default
    public Stores()
    {
        Id = Guid.NewGuid();
        _buildDate = DateTime.Now;
        Name = "Toko Default";
        Address = "Unkown Address";
        Status = StoreStatus.Closed; 
        Products = new List<Product>(); 
        
        // Setiap kali konstruktor (apapun) dipanggil, tambahkan counternya
        s_storeCounter++;
    }

    // Konstruktor utama
    public Stores(string name, string address)
    {
        Id = Guid.NewGuid();
        _buildDate = DateTime.Now;
        Name = name ?? "Warung Sederhana";
        Address = address;
        Status = StoreStatus.Closed; 
        Products = new List<Product>(); 

        // Tambahkan counter di sini juga
        s_storeCounter++;
    }

    // --- METODE STATIC ---
    // Anda memanggil ini menggunakan Store.GetTotalStoresCreated()
    // Perhatikan: Metode static HANYA bisa mengakses anggota static lainnya (seperti s_storeCounter)
    // Ia TIDAK BISA mengakses 'Name' or 'Address' (karena ia tidak tahu milik tokoA atau tokoB)
    public static int GetTotalStoresCreated()
    {
        return s_storeCounter;
    }

    // --- Metode Instance (Non-Static) ---
    public void OpenStore()
    {
        Status = StoreStatus.Open;
        Console.WriteLine($"{Name} sekarang Buka!");
    }

    public void CloseStore()
    {
        Status = StoreStatus.Closed;
        Console.WriteLine($"{Name} sekarang Tutup.");
    }

    public bool IsOpen()
    {
        return Status == StoreStatus.Open;
    }

    public void AddProduct(Product product)
    {
        if (!IsOpen())
        {
            Console.WriteLine($"Error: {Name} masih tutup. Buka toko dulu.");
            return;
        }
        
        Products.Add(product);
        Console.WriteLine($"Produk '{product.Name}' ditambahkan ke {Name}.");
    }

    public void RemoveProduct(int productId)
    {
        int itemsRemoved = Products.RemoveAll(p => p.Id == productId);
        if (itemsRemoved > 0)
            Console.WriteLine($"Produk dengan ID {productId} berhasil dihapus.");
        else
            Console.WriteLine($"Produk dengan ID {productId} tidak ditemukan.");
    }

    public int GetTotalInventoryValue()
    {
        return Products.Sum(p => p.Price);
    }
    
    public void PrintInventory()
    {
        Console.WriteLine($"\n--- Inventaris untuk {Name} ({Address}) ---");
        if (Products.Count == 0)
        {
            Console.WriteLine("Toko masih kosong.");
            return;
        }
        
        foreach (var p in Products)
        {
            Console.WriteLine($"  [ID: {p.Id}] {p.Name} - Rp{p.Price:N0}");
            Console.WriteLine($"     {p.Description}");
        }
        Console.WriteLine($"--- Total Nilai Inventaris: Rp{GetTotalInventoryValue():N0} ---");
    }
}