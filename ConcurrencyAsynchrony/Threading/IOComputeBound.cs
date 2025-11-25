public class IOComputeBound
{
    public static void CompareIOCompute()
    {
        Console.WriteLine("Comparing I/O-bound vs Compute-bound operations...");
            
        // I/O-bound operation - waiting for external event
        Console.WriteLine("Starting I/O-bound operation (reading user input)...");
        Thread ioThread = new Thread(() => 
        {
            Console.WriteLine("I/O thread: Please type something and press Enter:");
            string input = Console.ReadLine() ?? "";  // This blocks waiting for I/O
            Console.WriteLine($"I/O thread: You entered: {input}");
        });
        ioThread.Start();
        
        // Compute-bound operation - CPU intensive work
        Console.WriteLine("Starting compute-bound operation (calculating prime numbers)...");
        Thread computeThread = new Thread(() => 
        {
            Console.WriteLine("Compute thread: Finding prime numbers up to 100000...");
            int primeCount = 0;
            for (int i = 2; i <= 100000; i++)
            {
                if (IsPrime(i)) primeCount++;
            }
            Console.WriteLine($"Compute thread: Found {primeCount} prime numbers");
        });
        computeThread.Start();
        
        // Demonstrate blocking vs spinning
        Console.WriteLine("\nBlocking vs Spinning comparison:");
        
        // Blocking approach (efficient)
        var blockingStart = DateTime.Now;
        Thread.Sleep(1000);  // Blocks, releases CPU
        var blockingEnd = DateTime.Now;
        Console.WriteLine($"Blocking approach took: {(blockingEnd - blockingStart).TotalMilliseconds}ms");
        
        // Spinning approach (inefficient - don't do this for long waits!)
        Console.WriteLine("Spinning approach (brief demo only)...");
        var spinStart = DateTime.Now;
        var endTime = DateTime.Now.AddMilliseconds(100);  // Only spin for 100ms
        while (DateTime.Now < endTime) { }  // Continuous spinning - wastes CPU!
        var spinEnd = DateTime.Now;
        Console.WriteLine($"Spinning approach took: {(spinEnd - spinStart).TotalMilliseconds}ms");
        Console.WriteLine("Note: Spinning wastes CPU cycles - use blocking for longer waits!");
        
        computeThread.Join();
        ioThread.Join();
    }

    public static bool IsPrime(int number)
    {
        if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0) return false;
        return true;
    }
}