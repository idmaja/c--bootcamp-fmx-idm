public interface IMathLogger
{
    void Log(string message);
}

public class MathClass
{
    private readonly IMathLogger _logger;

    public MathClass(IMathLogger logger)
    {
        _logger = logger;
    }

    public int Tambah(int a, int b)
    {
        _logger.Log($"Tambah {a} + {b} = {a+b}");
        return a + b;
    }
}
