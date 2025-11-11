public delegate int Transformer(int x);
class Util
{
    public static int Square(int x) => x * x;
    public static int Cube(int x) => x * x * x;
    public static void Transform(int[] values, Transformer t)
    {
        for (int i = 0; i < values.Length; i++)
            values[i] = t(values[i]);  // Apply the plugged-in transformation
    }
}
