using System.Net;
using Egen.Cmd;
using Egen.Config;

namespace Egen
{
    class Runner
    {
        public static void RunModule(IParser parser, string[] args)
        {
            parser.ParseArguments(args);
            parser.RunModule();
        }
    }
}
