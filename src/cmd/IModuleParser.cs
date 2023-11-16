using Egen.Config;

namespace Egen.Cmd
{
    public interface IModuleParser
    {
        void ParseArguments(string[] args);
        void ParseConfig(IModuleConfig config);
        void RunModule();
    }
}
