using Xunit;
using Egen;

namespace EgenTest
{
    public class SPFRecordRetrieverTests
    {
        [Fact]
        public void GetSPFRecords_ValidDomain_ReturnsSPFRecords()
        {
            string domain = "gmail.com";
            string[] spfRecords = SPFRecordRetriever.GetSPFRecords(domain);

            Assert.NotNull(spfRecords);
            Assert.NotEmpty(spfRecords);
        }

        [Fact]
        public void GetSPFRecords_InvalidDomain_ThrowsException()
        {
            string domain = "invalid-domain-that-does-not-exist.com";

            Exception ex = Assert.Throws<Exception>(() => SPFRecordRetriever.GetSPFRecords(domain));
            Assert.Contains("Error retrieving SPF records", ex.Message);
        }
    }
}
