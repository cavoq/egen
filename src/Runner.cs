using Egen.Cmd;

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
