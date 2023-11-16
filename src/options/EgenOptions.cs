using CommandLine;

namespace Egen.Options
{
    public class EgenOptions
    {
        [Value(0, MetaName = "module", HelpText = "Available modules: gen, check")]
        public string? ModuleName { get; set; }
    }
}
