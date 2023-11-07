using System.Text.Json;

namespace Egen {
    public class Config {
        public static void ReadConfig()
        {
            string jsonFilePath = "Config.json";

            try
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                JsonDocument document = JsonDocument.Parse(jsonContent);

                JsonElement root = document.RootElement;
                JsonElement emailGenerator = root.GetProperty("modules").GetProperty("emailgenerator");

                string defaultChars = emailGenerator.GetProperty("defaultchars").GetString();
                JsonElement defaultDomains = emailGenerator.GetProperty("defaultdomains");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: File '{jsonFilePath}' not found.");
            }
            catch (Exception ex)
            {
            Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
