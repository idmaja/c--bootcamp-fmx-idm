using System.Globalization;
using System.Text;

Console.WriteLine("-------------------------------------");
Console.WriteLine();

string email = "dhimasm999@gmail.com";
Console.WriteLine($"Email sebelum : {email}");

Console.Write($"Domain email \"{email.ToLower()}\" adalah ");
Console.Write(EmailValidation.GetEmailDomain(email));
Console.WriteLine();

Console.WriteLine(email.TrimEnd(['c', 'm'])); // ternyata Trim memakai array

// email.Insert(4, "akulaku");
Console.WriteLine($"Email Insert : {email.Insert(4, "-akulaku-")}");
Console.WriteLine($"Email Remove : {email.Remove(email.Length - 5)}");
Console.WriteLine($"Email Long Count : {email.LongCount()}");
Console.WriteLine($"Email Start With : {email.StartsWith('a')}");
Console.WriteLine("-------------------------------------");
Console.WriteLine();

decimal totalPembayaran = 128_000_000.10M;

Console.WriteLine($"Total Pembayaran : {totalPembayaran,0:C}");

decimal harga = 1250000.75m;
string rupiah = harga.ToString("C", new CultureInfo("id-ID"));

Console.WriteLine($"Total Pembayaran : {rupiah}");
Console.WriteLine(string.Equals("foo", "FOO", StringComparison.OrdinalIgnoreCase));

Console.WriteLine("-------------------------------------");
Console.WriteLine();

Console.WriteLine($"Build Report : {Report.BuildReport(["Dhimas", "Saya", "sedang"])}");

Console.WriteLine("-------------------------------------");
Console.WriteLine();

Console.WriteLine($"Get Message Bytes : {GetMessageBytes("Hello World")}");
Console.WriteLine($"Get Message Bytes : {GetMessageFromBytes([68, 61, 97])}");

byte[] GetMessageBytes(string message)
{
    return Encoding.UTF8.GetBytes(message);
}

string GetMessageFromBytes(byte[] data)
{
    return Encoding.UTF8.GetString(data);
}

Console.WriteLine("-------------------------------------");
Console.WriteLine();
// Console.ReadLine();