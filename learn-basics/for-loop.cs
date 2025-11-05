int jumlah = 1;
for (int counter = 1; counter <= 8; ++counter)
{
    Console.WriteLine("Perulangan ke-" + counter);

    if (counter % 5 == 0)
    {
        // Console.WriteLine("Menemukan perulangan ke-{0}, jumlah back to 1 !!!", counter);
        Console.WriteLine("Menemukan perulangan ke-{0} !!!", counter);
        // Console.WriteLine("Jumlah: {0}", jumlah);
        // jumlah = 1;
        continue;
    }

    jumlah *= counter;
}

Console.WriteLine("Jumlah: {0}", jumlah);
Console.WriteLine("Selesai");