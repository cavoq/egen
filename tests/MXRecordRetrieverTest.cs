using Egen;
using Xunit;

namespace EgenTest
{
    public class MXRecordRetrieverTests
    {
        [Fact]
        public void GetMXRecords_ValidDomain_ReturnsMXRecords()
        {
            string domain = "gmail.com";
            string[] mxRecords = MXRecordRetriever.GetMXRecords(domain);
            Console.WriteLine(mxRecords);
            Assert.NotEmpty(mxRecords);
        }

        [Fact]
        public void GetMXRecords_InvalidDomain_ThrowsException()
        {
            string domain = "invalidexamplein553validexampleinvalid.com"; 
            string[] mxRecords = MXRecordRetriever.GetMXRecords(domain);
            Assert.Empty(mxRecords);
        }
    }
}
