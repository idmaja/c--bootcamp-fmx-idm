
// INVOKE DELEGATES
BasicDelegate();


// ---------------------------- BASIC DELEGATE START -----------------------------
static void BasicDelegate()
{
    Console.WriteLine("----------------------------------------------");
    Console.WriteLine();

    // Basic Method
    Transformer TSquare = Util.Square;   // t1 menunjuk ke Square
    Transformer TCube = Util.Cube;     // t2 menunjuk ke Cube

    Console.WriteLine($"Hasil TSquare : {TSquare(3)}");  
    Console.WriteLine($"Hasil TCube : {TCube(3)}"); 

    Console.WriteLine("----------------------------------------------");
    Console.WriteLine();

    // Plug-in Methods
    int[] values = { 1, 2, 3, 4, 5 };
    Console.WriteLine($"Original values: [{string.Join(", ", values)}]");

    // Util.Transform(values, Util.Square); // delegate manual
    GenericType.TransformGeneric(values, GenericType.SquareGeneric); // Generic method
    Console.WriteLine($"After Square transform (Generic): [{string.Join(", ", values)}]");

    int[] result = GenericType.TransformGenericNonVoid(values, GenericType.SquareGeneric); // Generic method non void return
    Console.WriteLine($"After Square transform (Generic) Non Void: [{string.Join(", ", result)}]");

    Util.Transform(values, Util.Cube);
    Console.WriteLine($"After Cube transform: [{string.Join(", ", values)}]");
    
    values = new int[] { 1, 2, 3, 4, 5 }; // Reset values
    Util.Transform(values, x => x + 10);
    Console.WriteLine($"After +10 transform: [{string.Join(", ", values)}]");

    Console.WriteLine("----------------------------------------------");
    Console.WriteLine();
    
    // Static vs instance methods
    Transformer TDouble = MathOps.Double; // static method

    MathOps ops = new MathOps();
    Transformer TTriple = ops.Triple; // instance method

    Console.WriteLine($"Hasil TDouble : {TDouble(5)}");
    Console.WriteLine($"Hasil TTriple : {TTriple(5)}"); 
    
    // Multicast delegate
    Console.WriteLine("----------------------------------------------");
    Console.WriteLine();

    ProgressReporter p = Report.WriteToConsole;
    p += Report.WriteToDebug; // multicast, sekarang 2 target

    Report.HardWork(p);

    Console.WriteLine("----------------------------------------------");
    Console.WriteLine();
}
// ---------------------------- BASIC DELEGATE END -----------------------------