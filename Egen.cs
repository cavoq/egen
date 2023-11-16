using Egen.Cmd;
using Egen.Config;

namespace Egen
{
    class Egen
    {
        [STAThread]
        public static void Main(string[] args)
        {
            string configFilePath = "config.json";
            ConfigManager configManager = new ConfigManager(configFilePath);

            if (args.Length == 0) return;
            
            IParser? parser = null;
            IModuleConfig? config = null;

            string moduleIdentifier = args[0];
            string[] moduleArgs = new string[args.Length - 1];
            Array.Copy(args, 1, moduleArgs, 0, moduleArgs.Length);

            switch (moduleIdentifier)
            {
                case "gen":
                    config = configManager.GetModuleConfig<EmailGeneratorConfig>("emailgenerator");
                    parser = new GenerationParser();
                    break;
            }

            if (parser == null) return;
            if (config == null) return;

            Runner.RunModule(parser, config, moduleArgs);
        }
    }
}
