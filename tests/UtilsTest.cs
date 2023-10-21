using Egen;
using Xunit;

namespace EgenTest
{
    public class UtilsTests
    {
        [Fact]
        public void SaveToFile_Success()
        {
            string content = "Test Content";
            string filePath = "testfile.txt";

            Utils.SaveToFile(content, filePath);

            Assert.True(File.Exists(filePath));
            string fileContent = File.ReadAllText(filePath);
            Assert.Equal(content, fileContent);
        }

        [Fact]
        public void SaveToFile_Exception()
        {
            string content = "Test Content";
            string filePath = "";

            Exception ex = Assert.Throws<Exception>(() => Utils.SaveToFile(content, filePath));
            Assert.Contains("Error:", ex.Message);
        }
    }
}
