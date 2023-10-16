public class EmailGenerator
{
    private readonly string[] domains = { "gmail.com", "yahoo.com", "hotmail.com", "example.com" };
    private Random random = new Random();

    public string GenerateRandomEmail(uint length = 16, string? customDomain = null)
    {
        string domain = customDomain ?? domains[random.Next(domains.Length)];
        
        string username = GenerateRandomString((int)length);
        string email = $"{username}@{domain}";
        
        return email;
    }

    private string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
