using System.Text;

Console.Write("Input panjang : ");
string? inputuser = Console.ReadLine();
long panjang = string.IsNullOrWhiteSpace(inputuser) || !long.TryParse(inputuser, out long hasil) ? 15 : hasil;

var sbOutput = new StringBuilder();
string output = "";

for (int i = 1; i < panjang + 1; i++)
{
    bool modBy3 = i % 3 == 0; bool modBy4 = i % 4 == 0;
    bool modBy5 = i % 5 == 0; bool modBy7 = i % 7 == 0;
    bool modBy9 = i % 9 == 0;

    if (modBy3) output += "foo";
    if (modBy5) output += "bar";
    if (modBy7) output += "jazz";

    if (modBy3 && modBy9) output = "huzz";
    else if (modBy4) output = "baz";

    if (output == "") output = i.ToString();
    if (i != 1) sbOutput.Append(", ");
    sbOutput.Append(output);
    output = "";
}

Console.WriteLine(sbOutput.ToString());
Console.ReadLine();
