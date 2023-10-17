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
        }
    }
}
