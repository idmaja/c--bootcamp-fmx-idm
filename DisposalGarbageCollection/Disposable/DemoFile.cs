sealed class DemoFile : IDisposable
{
    private readonly FileStream _stream;

    public DemoFile(string path)
    {
        _stream = new FileStream(path, FileMode.OpenOrCreate);
    }

    public void WriteText(string text)
    {
        using var writer = new StreamWriter(_stream, leaveOpen: true);
        writer.WriteLine(text);
        writer.Flush();
    }

    public void Dispose()
    {
        // Lepaskan resource yang dimiliki
        _stream?.Dispose();
    }
}