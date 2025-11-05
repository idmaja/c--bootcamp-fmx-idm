int integerNumber = 10;
double doubleNumber = integerNumber; // Implicit conversion from int to double

double anotherDouble = 5.7;
int anotherInt = (int)anotherDouble; // Explicit conversion from double to int

Console.WriteLine("Integer: {0}, Double: {1}", integerNumber, doubleNumber);
Console.WriteLine("Another Double: {0}, Another Int: {1}", anotherDouble, anotherInt);

/// ------------------------------------------------------------------------------

/*
kenapa explicit karena konversi dari tipe data dengan presisi lebih tinggi (double) ke tipe data dengan presisi lebih rendah (int)
memerlukan penanganan khusus untuk menghindari kehilangan data atau kesalahan.
*/