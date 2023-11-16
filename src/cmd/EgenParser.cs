using CommandLine;
using Egen.Config;
using Egen.Options;

namespace Egen.Cmd
{
    public class EgenParser
    {
        private EgenOptions options = new EgenOptions();
        private ConfigManager config;
        private IModuleParser? moduleParser;
        private IModuleConfig? moduleConfig;
        private string[]? moduleArgs;

        public EgenParser(string configFilePath = "config.json")
        {
            config = new ConfigManager(configFilePath);
        }

        public void ParseArguments(string[] args)
        {
            Parser parser = new Parser(settings =>
            {
                settings.HelpWriter = Console.Out;
            });

            if (args.Length == 0)
            {
                parser.ParseArguments<EgenOptions>(new string[] { "--help" });
                return;
            }

            string moduleIdentifier = args[0];
            moduleArgs = args.Skip(1).ToArray();

            parser.ParseArguments<EgenOptions>(args.Take(1).ToArray())
                .WithParsed(opts =>
                {
                    if (opts.ModuleName == "gen")
                    {
                        moduleParser = new GenerationParser();
                        moduleConfig = config.GetModuleConfig<EmailGeneratorConfig>("EmailGenerator");
                    }
                });
        }

        public void Run()
        {
            if (moduleParser == null || moduleConfig == null || moduleArgs == null)
            {
                return;
            }

            Runner.RunModule(moduleParser, moduleConfig, moduleArgs);
        }
    }
}
