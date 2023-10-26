using Egen.Cmd;

namespace Egen
{
    class Egen
    {
        [STAThread]
        public static void Main(string[] args)
        {
            if (args.Length == 0) return;
            
            IParser? parser = null;
            
            string moduleIdentifier = args[0];
            string[] moduleArgs = new string[args.Length - 1];
            Array.Copy(args, 1, moduleArgs, 0, moduleArgs.Length);

            switch (moduleIdentifier)
            {
                case "gen":
                    parser = new GenerationParser();
                    break;
                    // ...
            }

            if (parser == null) return;
            Runner.RunModule(parser, moduleArgs);
        }
    }
}
