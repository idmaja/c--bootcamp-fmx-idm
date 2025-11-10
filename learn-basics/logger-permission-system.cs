using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// ============================
// 1️⃣ Enum dengan [Flags]
// ============================
[Flags]
public enum Permission
{
    None = 0,
    Read = 1,
    Write = 2,
    Delete = 4,
    Admin = 8
}

// ============================
// 2️⃣ Class yang bisa diserialisasi
// ============================
[Serializable]
public class User
{
    public string Name { get; set; }
    public Permission Access { get; set; }

    public override string ToString()
        => $"{Name} ({Access})";
}

// ============================
// 3️⃣ Logger dengan atribut debugging dan Caller Info
// ============================
public static class Logger
{
    [Conditional("DEBUG")]
    public static void Log(
        string message,
        [CallerMemberName] string caller = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0)
    {
        Console.WriteLine($"[LOG] {message} (from {caller} at line {line})");
    }
}

// ============================
// 4️⃣ Class lama dengan [Obsolete]
// ============================
[Obsolete("Gunakan NewMathClass sebagai pengganti.")]
public static class OldMathClass
{
    public static int Add(int a, int b) => a + b;
}

// ============================
// 5️⃣ Versi baru pengganti class lama
// ============================
public static class NewMathClass
{
    public static int Add(int a, int b)
    {
        Logger.Log("Menjalankan penjumlahan");
        return a + b;
    }
}

// ============================
// Main Program
// ============================
public class Program
{
    public static void Main()
    {
        // Membuat user dengan kombinasi hak akses
        var user = new User
        {
            Name = "Saya",
            Access = Permission.Read | Permission.Write
        };
        Console.WriteLine(user);

        // Mengecek apakah user punya hak Write
        if ((user.Access & Permission.Write) != 0)
            Console.WriteLine("User dapat menulis file.");

        // Memanggil class lama (akan muncul peringatan)
        int sumOld = OldMathClass.Add(3, 4);
        Console.WriteLine($"Old sum: {sumOld}");

        // Memanggil versi baru
        int sumNew = NewMathClass.Add(10, 5);
        Console.WriteLine($"New sum: {sumNew}");
    }
}
