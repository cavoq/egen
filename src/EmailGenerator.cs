namespace Egen
{
    public class EmailGenerator
    {
        private readonly int minEmailLength = 6;
        private readonly Random random = new Random();

        public string GenerateRandomEmail(int length, string domain, string chars)
        {
            if (length < minEmailLength) {
                throw new ArgumentException($"Email length must be at least {minEmailLength}");
            }

            string username = GenerateRandomString(length, chars);
            string email = $"{username}@{domain}";

            return email;
        }

        // TODO: Support different formats
        public string[] GenerateEmails(string[] domains, string chars, int length)
        {
            string[] emails = new string[domains.Length];

            for (int i = 0; i < domains.Length; ++i)
            {
                string randomDomain = domains[random.Next(domains.Length)];

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
