namespace Egen.Config
{
    public class EmailGeneratorConfig: IModuleConfig
    {
        public int DefaultEmailLength { get; set; }
        public required string[] DefaultDomains { get; set; }
        public required string DefaultChars { get; set; }
    }
}
