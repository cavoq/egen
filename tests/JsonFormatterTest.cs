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
            Assert.Equal(expectedOutput, json);
        }

        [Fact]
        public void TestValidArrayInput()
        {
            JsonFormatter formatter = new JsonFormatter();
            string[] validInput = new string[]
            {
                "name: John Doe\nage: 30\noccupation: Software Engineer",
                "name: David Doe\nage: 24\noccupation: Systems Admin"
            };
            string expectedOutput = @"[
{
  ""name"": ""John Doe"",
  ""age"": ""30"",
  ""occupation"": ""Software Engineer""
},
{
  ""name"": ""David Doe"",
  ""age"": ""24"",
  ""occupation"": ""Systems Admin""
}
]";
            string json = formatter.Format(validInput);
            Assert.Equal(expectedOutput, json);
        }
    }
}
