/// <summary>
/// partial butuh partial class. Biasanya terpecah beberapa file, di sini digabung supaya terlihat.
/// </summary>


public partial class OrderProcessor
{
    // partial method, harus void dan implicit private
    partial void OnBeforeProcess(int orderId);

    public void Process(int orderId)
    {
        OnBeforeProcess(orderId); // dipanggil sebelum proses utama
        Console.WriteLine($"Processing order {orderId}");
    }
}

// implementasi partial method di bagian class lain
public partial class OrderProcessor
{
    partial void OnBeforeProcess(int orderId)
    {
        Console.WriteLine($"Before process order {orderId}");
        Console.WriteLine($"OrderId * OrderId : {orderId * orderId} \n");
    }
}