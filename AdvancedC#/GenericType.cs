class GenericType
{
    public static int SquareGeneric(int x) => x * x;
    public static void TransformGeneric<T>(T[] values, Func<T, T> transformer)
    {
        for (int i = 0; i < values.Length; i++)
            values[i] = transformer(values[i]);
    }

    public static T[] TransformGenericNonVoid<T>(T[] values, Func<T, T> transformer)
    {
        // Console.WriteLine($"values : {string.Join(", ", values)}");
        T[] result = new T[values.Length];
        for (int i = 0; i < values.Length; i++)
            result[i] = transformer(values[i]);
        return result;
    }

    public static void TransformActionGeneric<T>(T[] values, Action<T> transformer)
    {
        foreach (T value in values)
            transformer(value);
    }

    /// <summary>
    /// tidak perlu membuat delegate sendiri karena di C# sudah ada yaitu pakai Func<TKey, TValue>
    /// </summary>
}