// ---- Thread Properties and Lifecycle ----
Console.WriteLine("Examining thread properties and lifecycle...");
            
// Create a thread but don't start it yet
Thread worker = new Thread(DoSomeWork);
worker.Name = "WorkerThread";  // Naming helps with debugging

Console.WriteLine($"\n{TimeStamp()} Before Start - IsAlive: {worker.IsAlive}\n");
Console.WriteLine($"{TimeStamp()} Thread Name: {worker.Name}\n");
// Console.WriteLine($"{TimeStamp()} Thread Current Culture: {worker.CurrentCulture}\n");
// Console.WriteLine($"{TimeStamp()} Thread Current UI Culture: {worker.CurrentUICulture}\n");
Console.WriteLine($"{TimeStamp()} Is Background: {worker.IsBackground}\n");
Console.WriteLine($"{TimeStamp()} Thread State: {worker.ThreadState}\n");

// Start the thread
worker.Start();
Console.WriteLine($"{TimeStamp()} After Start - IsAlive: {worker.IsAlive}\n");
Console.WriteLine($"{TimeStamp()} Thread State: {worker.ThreadState}\n");

// current thread info
Console.WriteLine($"{TimeStamp()} Current thread name: {Thread.CurrentThread.Name ?? "Main"}\n");
Console.WriteLine($"{TimeStamp()} Current thread ID: {Thread.CurrentThread.ManagedThreadId}\n");
Console.WriteLine($"{TimeStamp()} Is thread pool thread: {Thread.CurrentThread.IsThreadPoolThread}\n");

// Wait for completion
// Join() hanya memastikan thread utama menunggu sampai worker selesai.
worker.Join();
Console.WriteLine($"{TimeStamp()} After Join - IsAlive: {worker.IsAlive}\n");
Console.WriteLine($"{TimeStamp()} Final Thread State: {worker.ThreadState}\n");


static void DoSomeWork()
{
    Console.WriteLine($"{TimeStamp()} Worker thread starting on thread ID: {Thread.CurrentThread.ManagedThreadId}\n");
    Thread.Sleep(5000); 
    Console.WriteLine($"{TimeStamp()} Worker thread finishing\n");
}

static string TimeStamp() => DateTime.Now.ToString("HH:mm:ss.fff");


// ---- IO vs Compute Bound ------
IOComputeBound.CompareIOCompute();


// ----- Locking ------
Locking.TambahBarang();