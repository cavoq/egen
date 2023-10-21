using Xunit;
using Egen;

namespace EgenTest {
    public class EmailValidatorTest
    {
        [Fact]
        public void TestValidEmails()
        {
            string[] validEmails = new string[]
            {
                "test@example.com",
                "user@domain.co",
                "john.doe123@sub.domain.com"
            };

            foreach (string email in validEmails)
            {
                Assert.True(EmailValidator.IsValidEmail(email));
            }
        }

        [Fact]
        public void TestInvalidEmails()
        {
            string[] invalidEmails = new string[]
            {
                "invalidemail.com",
                "missing@domain",
                "user@.com",
                "@domain.com"
            };

            foreach (string email in invalidEmails)
            {
                Assert.False(EmailValidator.IsValidEmail(email));
            }
        }
    }
}
