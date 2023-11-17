using Xunit;
using Egen.Config;

namespace EgenTest
{
    public class ConfigurationManagerTests
    {
        [Fact]
        public void GetModuleConfig_EmailGenerator_ReturnsValidConfig()
        {
            string testConfigJson = @"
            {
                ""Modules"": {
                    ""emailgenerator"": {
                        ""defaultchars"": ""ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"",
                        ""defaultdomains"": [""gmail.com"", ""yahoo.com"", ""hotmail.com"", ""example.com""]
                    }
                }
            }";

            string tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, testConfigJson);

            ConfigManager configManager = new ConfigManager(tempFilePath);
            var moduleConfig = configManager.GetModuleConfig<EmailGeneratorConfig>("emailgenerator");

            Assert.NotNull(moduleConfig);
            Assert.Equal("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", moduleConfig.DefaultChars);
            Assert.Equal(new List<string> { "gmail.com", "yahoo.com", "hotmail.com", "example.com" }, moduleConfig.DefaultDomains);

            File.Delete(tempFilePath);
        }
    }
}
