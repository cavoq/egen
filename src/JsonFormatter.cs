namespace Egen
{
    public class JsonFormatter : IFormatter
    {
        public string Format(string input)
        {
            string[] lines = input.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string formattedString = string.Join(",\n", lines.Select(line =>
            {
                string[] parts = line.Split(':');
                string key = parts[0].Trim();
                string value = parts[1].Trim();
                return $"  \"{key}\": \"{value}\"";
            }));
            return $"{{\n{formattedString}\n}}";
        }

        public string Format(string[] input)
        {
            string[] formattedStrings = input.Select(Format).ToArray();
            return $"[\n{string.Join(",\n", formattedStrings)}\n]";
        }
    }
}
