/// <summary>
/// Conditional compilation membuat kode tertentu ikut dikompilasi hanya 
/// jika simbol tertentu aktif. Simbol dicek saat compile. Kode yang tidak memenuhi 
/// kondisi tidak pernah masuk ke hasil build.
/// </summary>

#define DEBUG

#if TESTMODE
        Console.WriteLine("Test mode aktif");
#endif

#if TESTMODE
    Console.WriteLine("Test");
#elif DEVMODE
    Console.WriteLine("Dev");
#else
    Console.WriteLine("Normal");
#endif

Console.WriteLine("Hello, World!");
