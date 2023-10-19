using Whois;

namespace Egen
{
    public class WhoisLookup
    {
        public static string PerformLookup(string domain)
        {
            Whois.WhoisLookup lookup = new Whois.WhoisLookup();
            WhoisResponse response = lookup.Lookup(domain);

            string registrar = response.Registrar?.Name ?? "N/A";
            string registrantName = response.Registrant?.Name ?? "N/A";
            string registrantOrganization = response.Registrant?.Organization ?? "N/A";

            return $"Registrar: {registrar}\n" +
                   $"Registrant Name: {registrantName}\n" +
                   $"Registrant Organization: {registrantOrganization}\n";
        }
    }
}
