using Xunit;
using Egen;

namespace EgenTest {
    public class EmailGeneratorTests
    {
        [Fact]
        public void GenerateRandomEmail_Length10()
        {
            var emailGenerator = new EmailGenerator();
            string result = emailGenerator.GenerateRandomEmail(10);
            Assert.NotNull(result);
            Assert.Contains("@", result);
            Assert.Equal(10, result.Split("@")[0].Length);
        }

        [Fact]
        public void GenerateEmails_ReturnsValidEmails()
        {
            string[] domains = new string[] { "example.com", "test.com" };
            string chars = "abcdefghijklmnopqrstuvwxyz";
            EmailGenerator generator = new EmailGenerator();

            string[] emails = generator.GenerateEmails(domains, chars);

            Assert.NotNull(emails);
            Assert.Equal(domains.Length, emails.Length);
            foreach (string email in emails)
            {
                Assert.True(EmailValidator.IsValidEmail(email));
            }
        }
    }
}
