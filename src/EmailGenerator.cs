namespace Egen
{
    public class EmailGenerator
    {
        private const string defaultChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private readonly string[] defaultDomains = { "gmail.com", "yahoo.com", "hotmail.com", "example.com" };
        private readonly Random random = new Random();

        public string GenerateRandomEmail(uint length = 16, string? customDomain = null, string chars = defaultChars)
        {
            string domain = customDomain ?? defaultDomains[random.Next(defaultDomains.Length)];

            string username = GenerateRandomString((int)length, chars);
            string email = $"{username}@{domain}";

            return email;
        }

        // TODO: Support different formats
        public string[] GenerateEmails(string[]? domainList = null, string chars = defaultChars)
        {
            string[] domains = domainList ?? defaultDomains;
            string[] emails = Array.Empty<string>();
            
            for (int i = 0; i < domains.Length; ++i) 
            {
                uint length = 16;
                string randomDomain = domains[random.Next(defaultDomains.Length)];
                
                emails[i] = GenerateRandomEmail(length, randomDomain, chars); 
            }

            return emails;
        }

        private string GenerateRandomString(int length, string chars)
        {
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
