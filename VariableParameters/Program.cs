// -----------------------------------------------------------
// REF LOCAL

int[] scores = { 85, 92, 78, 96, 88 };
// Create a reference to an array element
ref int highestScore = ref scores[3];
// Modify reference target (example)
highestScore = 100;

// Print to verify
// Console.WriteLine(scores[3]); // Output: 100
Console.WriteLine($"Updated array: [{string.Join(", ", scores)}] \n");

// Usage
var processor = new DataProcessor();
ref int maxValue = ref processor.FindMaximum();
// maxValue *= 2; // Doubles the maximum value in the original array
Console.WriteLine($"Doubled maximum value: {maxValue}");

// ----------------------------------------------
// REF RETURNS

// static string x = "Old Value";
// static ref readonly string GetX() => ref x;
// Console.WriteLine(x);         // Output: New Value
// Console.WriteLine(GetX());

class DataProcessor
{
    private int[] data = { 10, 20, 30, 40, 50 };

    // Return a reference to the maximum element
    public ref int FindMaximum()
    {
        int maxIndex = 0;
        for (int i = 1; i < data.Length; i++)
        {
            if (data[i] > data[maxIndex])
                maxIndex = i;
        }
        return ref data[maxIndex];
    }
}