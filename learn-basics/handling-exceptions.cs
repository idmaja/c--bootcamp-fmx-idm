try
{
    string content = File.ReadAllText("nonexistentfile.txt");
    Console.WriteLine(content);
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred while trying to read the file.");
    Console.WriteLine($"Error details: {ex.Message}");
    // throw;
}
finally
{
    Console.WriteLine("Execution of the try-catch block is complete.");
}