using System.Security.Cryptography.X509Certificates;

public class MainClass
{
    public int Tambah(int angkaPertama, int angkaKedua)
    {
        return angkaPertama + angkaKedua;
    }

    public int Kurang(int angkaPertama, int angkaKedua)
    {
        return angkaPertama - angkaKedua;
    }

    public int Kali(int angkaPertama, int angkaKedua)
    {
        return angkaPertama * angkaKedua;
    }

    public int Bagi(int angkaPertama, int angkaKedua)
    {
        return angkaPertama / angkaKedua;
    }
}