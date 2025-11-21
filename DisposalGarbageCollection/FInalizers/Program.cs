
GoodFinalizerExample goodFinalizerExample = new GoodFinalizerExample("GoodFinalizerExample");
goodFinalizerExample.DoSomeWork();


public class GoodFinalizerExample
{
    private readonly string _name;
    private IntPtr _unmanagedResource; // Simulated unmanaged resource
    private bool _disposed = false;

    public GoodFinalizerExample(string name)
    {
        _name = name;
        _unmanagedResource = new IntPtr(12345); // Simulate unmanaged resource
        Console.WriteLine($"  → {_name} created with unmanaged resource");
    }

    /// <summary>
    /// Proper finalizer implementation following best practices:
    /// - Executes quickly
    /// - Handles exceptions properly
    /// - Only cleans up unmanaged resources
    /// - Doesn't access other managed objects
    /// </summary>
    ~GoodFinalizerExample()
    {
        try
        {
            Console.WriteLine($"  ✅ Good finalizer executing for {_name}");
            
            // Check if already cleaned up
            if (_disposed)
            {
                Console.WriteLine($"     Already cleaned up - skipping");
                return;
            }

            // Only clean up unmanaged resources
            if (_unmanagedResource != IntPtr.Zero)
            {
                Console.WriteLine($"     Releasing unmanaged resource for {_name}");
                _unmanagedResource = IntPtr.Zero;
            }

            _disposed = true;
            Console.WriteLine($"     Finalizer completed successfully for {_name}");
        }
        catch (Exception ex)
        {
            // NEVER let exceptions escape from finalizers!
            // This would crash the entire application
            Console.WriteLine($"     Error in finalizer for {_name}: {ex.Message}");
        }
    }

    /// <summary>
    /// Example method that uses the object's resources.
    /// </summary>
    public void DoSomeWork()
    {
        if (_disposed)
            throw new ObjectDisposedException(_name);
            
        Console.WriteLine($"{_name} is working with unmanaged resource");
    }
}

