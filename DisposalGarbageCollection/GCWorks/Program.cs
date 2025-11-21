/// <summary>
/// jadi disini kita men trigger GC
/// karena ketika app kita alokasi unmanaged memroy, 
/// GC harus diberitahu agar dia aktif
/// </summary>

Console.WriteLine("Memory Pressure - Informing GC About Unmanaged Memory");
Console.WriteLine("====================================================");
Console.WriteLine("When your app allocates unmanaged memory, the GC doesn't know about it");
Console.WriteLine("Memory pressure helps GC make informed collection decisions\n");

long managedBefore = GC.GetTotalMemory(false);
Console.WriteLine($"Managed memory before: {managedBefore:N0} bytes");

// Simulate allocation of unmanaged memory (e.g., via P/Invoke, COM)
long unmanagedBytes = 50 * 1024 * 1024; // 50MB of "unmanaged" memory

Console.WriteLine($"Simulating allocation of {unmanagedBytes:N0} bytes of unmanaged memory");
Console.WriteLine("Without memory pressure, GC doesn't know about this allocation");

// Tell the GC about our unmanaged memory allocation
Console.WriteLine("Adding memory pressure to inform GC about unmanaged allocation...");
GC.AddMemoryPressure(unmanagedBytes);

// Show GC behavior with memory pressure
int gen0Before = GC.CollectionCount(0);
int gen1Before = GC.CollectionCount(1);
int gen2Before = GC.CollectionCount(2);

// Allocate some managed memory to trigger potential collections
Console.WriteLine("Allocating managed memory to see GC behavior with memory pressure...");
var managedObjects = new List<byte[]>();
for (int i = 0; i < 100; i++)
{
    managedObjects.Add(new byte[100_000]); // 100KB each
}

int gen0After = GC.CollectionCount(0);
int gen1After = GC.CollectionCount(1);
int gen2After = GC.CollectionCount(2);

Console.WriteLine($"GC collections triggered:");
Console.WriteLine($"  Gen0: {gen0After} {gen0Before}");
Console.WriteLine($"  Gen1: {gen1After} {gen1Before}");
Console.WriteLine($"  Gen2: {gen2After} {gen2Before}");

// Simulate freeing the unmanaged memory
Console.WriteLine($"\nSimulating release of {unmanagedBytes:N0} bytes of unmanaged memory");
GC.RemoveMemoryPressure(unmanagedBytes);
Console.WriteLine("Memory pressure removed - GC now knows memory was freed");

long managedAfter = GC.GetTotalMemory(false);
Console.WriteLine($"Managed memory after: {managedAfter:N0} bytes");

Console.WriteLine("\nAlways pair AddMemoryPressure with RemoveMemoryPressure!");
Console.WriteLine("This helps GC make optimal collection timing decisions");

GC.KeepAlive(managedObjects);
Console.WriteLine();