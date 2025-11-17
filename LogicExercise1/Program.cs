using System.Text;

Console.Write("Input panjang : ");
string? inputuser = Console.ReadLine();
long panjang = string.IsNullOrWhiteSpace(inputuser) || !long.TryParse(inputuser, out long hasil) ? 15 : hasil;

var sbOutput = new StringBuilder();

for (int i = 1; i < panjang + 1; i++)
{
    string output = "";

    if (i % 3 == 0) output += "foo";
    if (i % 5 == 0) output += "bar";
    if (i % 7 == 0) output += "jazz";
    if (output == "") output = i.ToString();

    if (i % 3 == 0 && i % 5 == 0 && i % 7 == 0) output = "foobarjazz";
    else if (i % 3 == 0 && i % 5 == 0) output = "foobar";
    else if (i % 3 == 0 && i % 9 == 0) output = "huzz";
    else if (i % 3 == 0 && i % 7 == 0) output = "foojazz";
    else if (i % 4 == 0) output = "baz";

    if (i != 1) sbOutput.Append(", ");
    sbOutput.Append(output);
}

Console.WriteLine(sbOutput.ToString());
Console.ReadLine();
