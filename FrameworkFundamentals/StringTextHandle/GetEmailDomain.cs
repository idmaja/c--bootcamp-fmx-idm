class EmailValidation
{
    public static string GetEmailDomain(string email)
{
        if (string.IsNullOrEmpty(email)) return null!;

        int atIndex = email.IndexOf('@');
        if (atIndex < 0 || atIndex == email.Length - 1)
            return null!;

        return email.Substring(atIndex + 1);
    }

    public static bool IsSimpleEmailValid(string email)
{
        if (string.IsNullOrWhiteSpace(email))
            return false;

        // sangat sederhana, hanya contoh
        return email.Contains("@") && email.Contains(".");
    }
}