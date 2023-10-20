using System.Net;

namespace Egen
{
    public class SPFRecordRetriever
    {
        public static string[] GetSPFRecords(string domain)
        {
            try
            {
                var spfRecords = Dns.GetHostEntry(domain)
                                    .AddressList
                                    .Select(ip => ip.ToString())
                                    .ToArray();
                return spfRecords;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving SPF records for {domain}", ex);
            }
        }
    }
}
