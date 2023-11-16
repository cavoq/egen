using Egen.Cmd;
using Egen.Config;

namespace Egen
{
    class Runner
    {
        public static void RunModule(IModuleParser parser, IModuleConfig config, string[] args)
        {
            parser.ParseConfig(config);
            parser.ParseArguments(args);
            parser.RunModule();
        }
    }
}
