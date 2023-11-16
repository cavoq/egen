namespace Egen.Config
{
    public class EmailGeneratorConfig: IModuleConfig
    {
        public int DefaultEmailLength { get; set; }
        public string[]? DefaultDomains { get; set; }
        public string? DefaultChars { get; set; }
    }
}
