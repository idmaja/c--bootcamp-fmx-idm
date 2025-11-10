public static class Util
{
    public static void Tukar<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
}