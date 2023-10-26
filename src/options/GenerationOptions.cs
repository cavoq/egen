using CommandLine;

namespace Egen.Options
{
    public class GenerationOptions
    {
        [Option('l', "length", Default = 10, HelpText = "Length of generated emails")]
        public int EmailLength { get; set; }

        [Option('d', "domains", Default = "resources/defaultDomains.txt", HelpText = "Path to the file containing list of domains")]
        public string DomainsFilePath { get; set; }

        [Option('c', "chars", Default = "resources/defaultChars.txt", HelpText = "Path to the file containing allowed characters")]
        public string AllowedCharactersFilePath { get; set; }

        public string[] GetDomainList()
        {   
            return Utils.ReadListFromFile(DomainsFilePath);
        }

        public string GetAllowedCharacters()
        {
            return Utils.ReadCharactersFromFile(AllowedCharactersFilePath);
        }
    }
}
