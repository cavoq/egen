using Xunit;
using Egen;

namespace EgenTest
{
    public class WhoisLookupTest
    {
        [Fact]
        public void PerformLookup_ReturnsExpectedResult()
        {
            string domain = "gmail.com";
            string result = WhoisLookup.PerformLookup(domain);

            Console.WriteLine(result);
            Assert.NotNull(result);
            Assert.Contains("Registrar:", result);
            Assert.Contains("Registrant Name:", result);
            Assert.Contains("Registrant Organization:", result);
        }
    }
}
