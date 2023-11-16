using Egen.Cmd;

namespace Egen
{
    class Egen
    {
        [STAThread]
        public static void Main(string[] args)
        {   
            string configPath = "Config.json";
            EgenParser parser = new EgenParser(configPath);
            parser.ParseArguments(args);
            parser.Run();
        }
    }
}
