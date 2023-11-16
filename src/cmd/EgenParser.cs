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
            if (args.Length == 0)
            {
                Parser.Default.ParseArguments<EgenOptions>(new string[] { "--help" });
                return;
            }

            string moduleIdentifier = args[0];
            moduleArgs = new string[args.Length - 1];

            Parser.Default.ParseArguments<EgenOptions>(args)
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
