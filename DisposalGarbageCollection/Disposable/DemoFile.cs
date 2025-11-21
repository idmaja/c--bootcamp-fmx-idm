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
        writer.Flush(); // Flush itu untuk memaksa buffer menulis data ke tujuan aslinya
    }

    public void Dispose()
    {
        _stream?.Dispose(); // untuk Lepaskan resource yang dimiliki
    }
}