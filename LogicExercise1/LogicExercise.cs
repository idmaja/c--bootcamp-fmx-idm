using System.Text;

public class LogicExercise
{
    private readonly List<(int input, string output)> _rules = new();

    public void AddRule(int input, string output)
    {
        if (input == 0) throw new Exception("Angka input tidak bisa 0");

        _rules.Add((input, output));
    }

    public void ExecuteLoop(int panjang)
    {
        var sbOutput = new StringBuilder();
        string output = "";

        for (int i = 1; i < panjang + 1; i++)
        {
            foreach (var rule in _rules)
                if (i % rule.input == 0)
                    output += rule.output;

            if (output == "") 
                output = i.ToString();
            if (i != 1) 
                sbOutput.Append(", ");
                
            sbOutput.Append(output);
            output = "";
        }

        Console.WriteLine(sbOutput.ToString());
        Console.ReadLine();
    }
}