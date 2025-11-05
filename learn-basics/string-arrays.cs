string nama = "Apa aku adalah";

nama = nama.Remove(3, 1);
Console.WriteLine(nama);
nama = nama.Insert(3, " asdasd");
Console.WriteLine(nama);
nama = nama.Replace("asdasd", "B");
Console.WriteLine(nama);
nama = nama.ToUpper();
Console.WriteLine(nama);

if(nama.Contains("B"))
{
    nama = nama.Replace("B", "b");
}

Console.WriteLine(nama);