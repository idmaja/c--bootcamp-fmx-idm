class LogReader
{
    // Iterator: menghasilkan baris log satu per satu
    public static IEnumerable<string> ReadLogLines(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line; // kirim baris ke pemanggil
            }
        }
    }
}