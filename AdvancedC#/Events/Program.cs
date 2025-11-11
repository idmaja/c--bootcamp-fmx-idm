using System.Reflection;

var stock = new Stock();
        
stock.PriceChanged += Stock.Stock_PriceChanged;
stock.PriceChanged += Stock.Stock_PriceChanged_2;

stock.Price = 10m;
stock.Price = 12m;
stock.Price = 15m;

stock.NameChanged += Stock.Stock_NameChanged;

stock.Nama = "Rusdi";
stock.Nama = "Kamal";