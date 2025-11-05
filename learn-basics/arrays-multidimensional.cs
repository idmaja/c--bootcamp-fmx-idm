int[,] angka = { 
    { 1, 2, 3 }, { 4, 5, 6 } 
};

int[,,] angka2 = { 
    { 
        { 1, 2, 3 }, { 4, 5, 6 } 
    }, 
    { 
        { 7, 8, 9 }, { 10, 11, 12 } 
    } 
};

for (int i = 0; i < angka.GetLength(0); i++)
{
    for (int j = 0; j < angka.GetLength(1); j++)
    {
        Console.Write(angka[i, j] + " ");
    }
    Console.WriteLine();
} 

// Console.WriteLine(angka2[1, 0, 2]);

// Console.WriteLine(angka2.GetLength(2));
// Console.WriteLine(angka2.Length);