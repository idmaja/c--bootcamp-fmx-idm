using System;

namespace BootcampFmx
{
    public class Perhitungan
    {
        public static int Tambah(int a, int b)
        {
            return a + b;
        }

        public static int Kurang(int a, int b)
        {
            return a - b;
        }

        public static int Kali(int a, int b)
        {
            return a * b;
        }

        public static int Bagi(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Pembagi tidak boleh nol");
            }
            return a / b;
        }
    }
}