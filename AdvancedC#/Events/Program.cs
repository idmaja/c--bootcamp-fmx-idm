using System.Reflection;

var stock = new Stock();
        
stock.PriceChanged += Stock.Stock_PriceChanged;
stock.PriceChanged += Stock.Stock_PriceChanged_2; // tambahan subscriber

stock.Price = 10m;
stock.Price = 12m;
stock.Price = 15m;

Console.WriteLine();

stock.NameChanged += Stock.Stock_NameChanged;

stock.Nama = "Rusdi";
stock.Nama = "Kamal";

Console.WriteLine();

// var worker = new Worker();

// worker.ProgressChanged += Worker.Worker_ProgressChanged!;
// worker.ProgressChangedAction += Worker.Worker_ProgressChanged_Action;

// worker.DoWork();

Console.WriteLine();

var orderSystem = new OrderProcessingSystem();
var emailService = new EmailService();
var inventorySystem = new InventorySystem();
var auditLogger = new AuditLogger();
var loyaltyProgram = new LoyaltyProgram();
var returItem = new ReturItem();

// Wire up all the event handlers - this is the beauty of events
// Each service can independently subscribe to the events it cares about
orderSystem.OrderPlaced += emailService.OnOrderPlaced;
orderSystem.OrderPlaced += inventorySystem.OnOrderPlaced;
orderSystem.OrderPlaced += auditLogger.OnOrderPlaced;
orderSystem.OrderPlaced += loyaltyProgram.OnOrderPlaced;

orderSystem.OrderCancelled += emailService.OnOrderCancelled;
orderSystem.OrderCancelled += inventorySystem.OnOrderCancelled;
orderSystem.OrderCancelled += auditLogger.OnOrderCancelled;

orderSystem.OrderRetur += returItem.OnOrderCancelled;

// Process some orders - watch how all systems respond automatically
Console.WriteLine("Processing customer orders...\n");

var order1 = new CustomerOrder("john.doe@email.com", 29900000.99m, ["Laptop", "Kipas Angin"]);
var order2 = new CustomerOrder("jane.smith@email.com", 8900000.50m, ["Wireless Mouse", "Setrika", "Wajan"]);

orderSystem.PlaceOrder(order1);
Console.WriteLine();

orderSystem.PlaceOrder(order2);
Console.WriteLine();

// Cancel an order
orderSystem.CancelOrder(order1);
Console.WriteLine();

orderSystem.ReturOrder(order2);
Console.WriteLine();