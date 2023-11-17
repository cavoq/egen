using CommandLine;
using Egen.Config;
using Egen.Options;

namespace Egen.Cmd
{
    public class GenerationParser : IModuleParser
    {
        private readonly GenerationOptions options = new GenerationOptions();
        private readonly EmailGenerator emailGenerator = new EmailGenerator();
        private readonly Parser moduleParser = new Parser(settings =>
        {
            settings.HelpWriter = Console.Out;
            settings.AutoHelp = false;
            settings.AutoVersion = false;
        });

        public void ParseArguments(string[] args)
        {
            moduleParser.ParseArguments<GenerationOptions>(args)
                .WithParsed(opts =>
                {
                    options.Help = opts.Help;
                    options.EmailLength = opts.EmailLength;
                    options.DomainsFilePath = opts.DomainsFilePath;
                    options.AllowedCharactersFilePath = opts.AllowedCharactersFilePath;
                    options.Amount = opts.Amount;
                });
        }

        public void ParseConfig(IModuleConfig moduleConfig)
        {
            options.config = (EmailGeneratorConfig)moduleConfig;
        }

        public void RunModule()
        {
            if (options.Help)
            {
                GenerationOptions.DisplayHelp();
                return;
            }

            string? allowedCharacters = options.GetAllowedCharacters();
            string[]? domains = options.GetDomainList();
            int length = options.GetEmailLength();
            int amount = options.Amount;

            string[] emails = emailGenerator.GenerateEmails(domains, allowedCharacters, length, amount);
            Console.WriteLine(string.Join("\n", emails));
        }
    }
}
