DateTime sekarang = DateTime.Now;
Console.WriteLine("Sekarang: " + sekarang.ToString());
Console.WriteLine("Sekarang: " + sekarang.ToString("yyyy-MM-dd HH:mm:ss"));
Console.WriteLine("Sekarang: " + sekarang.ToShortDateString());
Console.WriteLine("Sekarang: " + sekarang.ToShortTimeString());
Console.WriteLine("Sekarang: " + sekarang.ToLongDateString());
Console.WriteLine("Sekarang: " + sekarang.ToLongTimeString());

Console.WriteLine(sekarang.AddDays(-2000).ToLongDateString());

Console.WriteLine(sekarang.Month);

DateTime tanggalLahir = new DateTime(1995, 5, 17);
Console.WriteLine("Tanggal Lahir: " + tanggalLahir.ToLongDateString());

DateTime ulangTahun = DateTime.Parse("2024-05-17");
Console.WriteLine("Ulang Tahun: " + ulangTahun.ToLongDateString());

TimeSpan umurku = DateTime.Now.Subtract(tanggalLahir);
Console.WriteLine("Umurku dalam hari: " + umurku.TotalDays + " hari");