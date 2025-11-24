
Console.Write("Input panjang : ");
string? inputLength = Console.ReadLine();
int panjang = string.IsNullOrWhiteSpace(inputLength) || !int.TryParse(inputLength, out int hasil) ? 15 : hasil;

LogicExercise logicExercise = new LogicExercise();

logicExercise.AddRule(3, "foo");
logicExercise.AddRule(4, "baz");
logicExercise.AddRule(5, "bar");
logicExercise.AddRule(7, "jazz");
logicExercise.AddRule(9, "huzz");

logicExercise.ExecuteLoop(panjang);