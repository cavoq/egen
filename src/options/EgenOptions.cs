using CommandLine;

namespace Egen.Options
{
    public class EgenOptions
    {
        private static readonly string[] availableModules = { "gen", "check" };

        [Value(0, MetaName = "module", HelpText = "Available modules: gen, check")]
        public string? ModuleName { get; set; }

        [Option('h', "help", HelpText = "Show help for egen cli tool")]
        public bool Help { get; set; }

        public static void DisplayHelp()
        {
            Console.WriteLine("Usage: egen <module> [OPTIONS]");
            Console.WriteLine();
            Console.WriteLine("Available modules:");
            foreach (var module in availableModules)
            {
                Console.WriteLine($"  {module}");
            }
            Console.WriteLine();
            Console.WriteLine("Options:");

            var properties = typeof(EgenOptions).GetProperties();
            foreach (var property in properties)
            {
                if (property.GetCustomAttributes(typeof(OptionAttribute), false).FirstOrDefault() is OptionAttribute optionAttribute)
                {
                    var optionNames = $"{(optionAttribute.ShortName != null ? $"-{optionAttribute.ShortName}, " : string.Empty)}--{optionAttribute.LongName}";
                    var helpText = optionAttribute.HelpText;
                    Console.WriteLine($"  {optionNames.PadRight(20)} {helpText}");
                }
            }
        }
    }
}
