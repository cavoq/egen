using System.Net;
using Egen.Cmd;
using Egen.Config;

namespace Egen
{
    class Runner
    {
        public static void RunModule(IParser parser, IModuleConfig config, string[] args)
        {
            parser.ParseConfig(config);
            parser.ParseArguments(args);
            parser.RunModule();
        }
    }
}
