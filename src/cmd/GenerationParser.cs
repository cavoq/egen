using CommandLine;
using Egen.Config;
using Egen.Options;

namespace Egen.Cmd
{
    public class GenerationParser : IParser
    {
        private GenerationOptions options;
        private readonly EmailGenerator emailGenerator = new EmailGenerator();

        public GenerationParser(IModuleConfig config)
        {
            options = new GenerationOptions(config);
        }

        public void ParseArguments(string[] args)
        {
            Parser.Default.ParseArguments<GenerationOptions>(args)
                .WithParsed(opts =>
                {
                    options.EmailLength = opts.EmailLength;
                    options.DomainsFilePath = opts.DomainsFilePath;
                    options.AllowedCharactersFilePath = opts.AllowedCharactersFilePath;
                });
        }

        public void RunModule()
        {
            string? allowedCharacters = options.GetAllowedCharacters();
            string[]? domains = options.GetDomainList();

            string[] emails = emailGenerator.GenerateEmails(domains, allowedCharacters);
            Console.WriteLine(string.Join("\n", emails));
        }
    }
}
