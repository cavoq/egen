using CommandLine;
using Egen.Config;
using Egen.Options;

namespace Egen.Cmd
{
    public class GenerationParser : IModuleParser
    {
        private GenerationOptions options = new GenerationOptions();
        private readonly EmailGenerator emailGenerator = new EmailGenerator();

        public void ParseArguments(string[] args)
        {
            Parser.Default.ParseArguments<GenerationOptions>(args)
                .WithParsed(opts =>
                {
                    options.EmailLength = opts.EmailLength;
                    options.DomainsFilePath = opts.DomainsFilePath;
                    options.AllowedCharactersFilePath = opts.AllowedCharactersFilePath;
                }).WithNotParsed(errs =>
                {
                    Parser.Default.ParseArguments<GenerationOptions>(new string[] { "--help" });
                });
        }

        public void ParseConfig(IModuleConfig moduleConfig)
        {
            options.config = (EmailGeneratorConfig)moduleConfig;
        }

        public void RunModule()
        {
            string? allowedCharacters = options.GetAllowedCharacters();
            string[]? domains = options.GetDomainList();
            int length = options.GetEmailLength();

            string[] emails = emailGenerator.GenerateEmails(domains, allowedCharacters, length);
            Console.WriteLine(string.Join("\n", emails));
        }
    }
}
