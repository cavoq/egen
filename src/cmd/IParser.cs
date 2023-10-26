namespace Egen.Cmd
{
    public interface IParser
    {
        void ParseArguments(string[] args);
        void RunModule();
    }
}
