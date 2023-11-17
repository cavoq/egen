using CommandLine;
using Egen.Config;

namespace Egen.Options
{
    public class GenerationOptions
    {
        public EmailGeneratorConfig config = new EmailGeneratorConfig();

        [Option('l', "length", Default = 10, HelpText = "Length of generated emails")]
        public int EmailLength { get; set; }

        [Option('d', "domains", HelpText = "Path to the file containing list of domains")]
        public string? DomainsFilePath { get; set; }

        [Option('c', "chars", HelpText = "Path to the file containing allowed characters")]
        public string? AllowedCharactersFilePath { get; set; }

        [Option('a', "amount", Default = 10, HelpText = "Amount of emails to generate")]
        public int Amount { get; set; }

        [Option('h', "help", HelpText = "Show help for email generation module")]
        public bool Help { get; set; }

        public int GetEmailLength()
        {
            if (config.DefaultEmailLength != 0 && EmailLength < 6)
            {
                return config.DefaultEmailLength;
            }

            return EmailLength;
        }

        public string[] GetDomainList()
        {
            if (DomainsFilePath == null && config.DefaultDomains != null)
            {
                return config.DefaultDomains;
            }

            return Utils.ReadListFromFile(DomainsFilePath);
        }

        public string GetAllowedCharacters()
        {
            if (AllowedCharactersFilePath == null && config.DefaultChars != null)
            {
                return config.DefaultChars;
            }

            return Utils.ReadCharactersFromFile(AllowedCharactersFilePath);
        }

        public static void DisplayHelp()
        {
            Console.WriteLine("Usage: egen gen [OPTIONS]");
            Console.WriteLine();
            Console.WriteLine("Generate emails");
            Console.WriteLine();
            Console.WriteLine("Options:");

            var properties = typeof(GenerationOptions).GetProperties();
            foreach (var property in properties)
            {
                if (property.GetCustomAttributes(typeof(OptionAttribute), false).FirstOrDefault() is OptionAttribute optionAttribute)
                {
                    var optionNames = $"{(optionAttribute.ShortName != null ? $"-{optionAttribute.ShortName}, " : string.Empty)}--{optionAttribute.LongName}";
                    var helpText = optionAttribute.HelpText;
                    Console.WriteLine($"  {optionNames.PadRight(20)} {helpText}");
                }
            }
        }
    }
}
