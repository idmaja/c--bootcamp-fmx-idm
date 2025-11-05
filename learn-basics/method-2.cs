static double Luas(double panjang = 10, double lebar = 5)
{
    return panjang * lebar;
}

double LuasPersegiPanjang = Luas(lebar:2.4, panjang:3.5);

Console.WriteLine("Luas Persegi Panjang: " + LuasPersegiPanjang);