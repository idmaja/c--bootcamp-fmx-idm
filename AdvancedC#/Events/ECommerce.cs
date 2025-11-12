public class CustomerOrder
{

    private Guid _orderId;
    private string _customerEmail;
    private decimal _amount;
    private string[] _productName;
    private DateTime _orderTime;

    public Guid OrderId => _orderId;
    public string CustomerEmail => _customerEmail;
    public decimal Amount => _amount;
    public string ProductName => string.Join(", ", _productName);
    public DateTime OrderTime => _orderTime;

    public CustomerOrder(string customerEmail, decimal amount, string[] productName)
    {
        _orderId = Guid.NewGuid();
        _customerEmail = customerEmail;
        _amount = amount;
        _productName = productName;
        _orderTime = DateTime.Now;
    }
}

// EventArgs for order events
public class OrderEventArgs : EventArgs
{
    public CustomerOrder Order { get; }
    public DateTime EventTime { get; }

    public OrderEventArgs(CustomerOrder order)
    {
        Order = order;
        EventTime = DateTime.Now;
    }
}

// Main order processing system - the event broadcaster
public class OrderProcessingSystem
{
    // Multiple events for different business scenarios
    public event EventHandler<OrderEventArgs>? OrderPlaced;
    public event EventHandler<OrderEventArgs>? OrderCancelled;
    public event EventHandler<OrderEventArgs>? OrderRetur;

    public void PlaceOrder(CustomerOrder order) // logic atau event di belakang tombol
    {
        Console.WriteLine($"Order System: Processing order #{order.OrderId} for {order.CustomerEmail}");
        Console.WriteLine($"  Product(s): [ {order.ProductName} ], Amount: ${order.Amount}");
        
        // Fire the event - all interested systems will be notified automatically
        OnOrderPlaced(new OrderEventArgs(order));
    }

    public void CancelOrder(CustomerOrder order)
    {
        Console.WriteLine($"Order System: Cancelling order #{order.OrderId}");

        OnOrderCancelled(new OrderEventArgs(order));
    }
    
    public void ReturOrder(CustomerOrder order)
    {
        Console.WriteLine($"Order System: Retured order #{order.OrderId}; Product(s) : [ {order.ProductName} ]");
        
        OnOrderRetur(new OrderEventArgs(order));
    }

    protected virtual void OnOrderPlaced(OrderEventArgs e) // aksi atau method seperti tombol
    {
        OrderPlaced?.Invoke(this, e);
    }

    protected virtual void OnOrderCancelled(OrderEventArgs e)
    {
        OrderCancelled?.Invoke(this, e);
    }

    protected virtual void OnOrderRetur(OrderEventArgs e)
    {
        OrderRetur?.Invoke(this, e);
    }
}

// Email service - independent subscriber
public class EmailService
{
    public void OnOrderPlaced(object? sender, OrderEventArgs e)
    {
        Console.WriteLine($"  Email Service: Sending confirmation to {e.Order.CustomerEmail}");
        Console.WriteLine($"    'Your order #{e.Order.OrderId} has been confirmed'");
    }

    public void OnOrderCancelled(object? sender, OrderEventArgs e)
    {
        Console.WriteLine($"  Email Service: Sending cancellation notice to {e.Order.CustomerEmail}");
        Console.WriteLine($"    'Your order #{e.Order.OrderId} has been cancelled'");
    }
}

// Inventory system - another independent subscriber
public class InventorySystem
{
    public void OnOrderPlaced(object? sender, OrderEventArgs e)
    {
        Console.WriteLine($"  Inventory System: Reserving {e.Order.ProductName} for order #{e.Order.OrderId}");
        Console.WriteLine($"    Inventory levels updated");
    }

    public void OnOrderCancelled(object? sender, OrderEventArgs e)
    {
        Console.WriteLine($"  Inventory System: Releasing reserved {e.Order.ProductName}");
        Console.WriteLine($"    Item returned to available inventory");
    }
}

// Audit logging - tracks all order activities
public class AuditLogger
{
    public void OnOrderPlaced(object? sender, OrderEventArgs e)
    {
        Console.WriteLine($"  Audit Logger: ORDER_PLACED - ID:{e.Order.OrderId}, " +
                        $"Customer:{e.Order.CustomerEmail}, Amount:${e.Order.Amount}");
    }

    public void OnOrderCancelled(object? sender, OrderEventArgs e)
    {
        Console.WriteLine($"  Audit Logger: ORDER_CANCELLED - ID:{e.Order.OrderId}");
    }
}

// Loyalty program - calculates reward points
public class LoyaltyProgram
{
    public void OnOrderPlaced(object? sender, OrderEventArgs e)
    {
        int points = (int)(e.Order.Amount / 10); // 1 point per $10 spent
        Console.WriteLine($"  Loyalty Program: Adding {points} points to {e.Order.CustomerEmail}");
        Console.WriteLine($"    Customer rewards balance updated");
    }
}

public class ReturItem
{
    public void OnOrderCancelled(object? sender, OrderEventArgs e)
    {
        Console.WriteLine($"  Retur Item: Retur Item #{e.Order.OrderId}");
        Console.WriteLine($"    Item returned to available inventory");
    }
}