using Egen;
using Xunit;

namespace EgenTest
{
    public class JsonFormatterTest
    {
        [Fact]
        public void TestValidnput()
        {
            JsonFormatter formatter = new JsonFormatter();
            string validInput = "name: John Doe\nage: 30\noccupation: Software Engineer";
            string expectedOutput = @"{
  ""name"": ""John Doe"",
  ""age"": ""30"",
  ""occupation"": ""Software Engineer""
}";

            string json = formatter.Format(validInput);
            Console.WriteLine(json);
            Assert.Equal(expectedOutput, json);
        }
    }
}
