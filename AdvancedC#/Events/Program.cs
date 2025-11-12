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

var worker = new Worker();

worker.ProgressChanged += Worker.Worker_ProgressChanged!;
worker.ProgressChangedAction += Worker.Worker_ProgressChanged_Action;

worker.DoWork();