using System.Text;

class Report
{
    public static string BuildReport(IEnumerable<string> items)
{
    var sb = new StringBuilder();

    sb.AppendLine("===== LAPORAN =====");
    foreach (var item in items)
    {
        sb.Append("- ").AppendLine(item);
    }
    sb.AppendLine("===================");

    return sb.ToString();
}
}