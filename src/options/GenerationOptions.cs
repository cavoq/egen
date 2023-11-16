using System.ComponentModel;
using CommandLine;
using Egen.Config;

namespace Egen.Options
{
    public class GenerationOptions
    {
        private readonly EmailGeneratorConfig config;
        public GenerationOptions(IModuleConfig config)
        {
            this.config = (EmailGeneratorConfig)config;
        }

        [Option('l', "length", Default = 10, HelpText = "Length of generated emails")]
        public int EmailLength { get; set; }

        [Option('d', "domains", HelpText = "Path to the file containing list of domains")]
        public string? DomainsFilePath { get; set; }

        [Option('c', "chars", HelpText = "Path to the file containing allowed characters")]
        public string? AllowedCharactersFilePath { get; set; }

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
    }
}
