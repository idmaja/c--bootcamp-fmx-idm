public interface IEnumerator // Interface Declaration
{
    bool MoveNext();      // Method
    object Current { get; } // Read-only Property
    void Reset();         // Method
}

internal class Countdown : IEnumerator // Implements the IEnumerator interface
{
    int count = 9;

    public bool MoveNext() => count-- > 0; // Implementation of MoveNext
    public object Current => count;        // Implementation of Current
    public void Reset() { throw new NotSupportedException(); } // Implementation of Reset
}