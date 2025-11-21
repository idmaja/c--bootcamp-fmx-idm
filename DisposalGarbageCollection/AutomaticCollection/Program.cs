for (int i = 0; i < 5; i++)
    Allocate();

Console.WriteLine("Memaksa GC");
GC.Collect();
GC.WaitForPendingFinalizers();

static void Allocate()
{
    byte[] buf = new byte[100000];
}