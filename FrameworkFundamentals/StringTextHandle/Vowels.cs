class Vowels
{
    public static int CountVowels(string text)
    {
        if (string.IsNullOrEmpty(text))
            return 0;

        int count = 0;
        foreach (char c in text.ToLowerInvariant())
        {
            if ("aiueo".Contains(c))
                count++;
        }
        return count;
    }
}