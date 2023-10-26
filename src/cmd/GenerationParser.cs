using CommandLine;
using Egen.Options;
using NuGet.Frameworks;

namespace Egen.Cmd
{
    public class GenerationParser : IParser
    {
        private readonly GenerationOptions options = new GenerationOptions();
        private readonly EmailGenerator emailGenerator = new EmailGenerator();

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
