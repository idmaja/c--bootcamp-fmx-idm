public delegate void ProgressReporter(int percent);

class Report
{
    public static void WriteToConsole(int percent) => Console.WriteLine($"(MULTICAST) Console: {percent}%");
    public static void WriteToDebug(int percent) => Console.WriteLine($"(MULTICAST) Debug: {percent}%");

    public static void HardWork(ProgressReporter reporter)
    {
        for (int i = 0; i <= 100; i += 25)
        {
            reporter(i); // panggil semua metode yang terdaftar
        }
    }

}