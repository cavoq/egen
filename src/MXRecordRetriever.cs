using DnsClient;

namespace Egen
{
    public class MXRecordRetriever
    {
        public static string[] GetMXRecords(string domain)
        {
            try
            {
                LookupClient lookup = new LookupClient();
                IDnsQueryResponse result = lookup.Query(domain, QueryType.MX);

                IEnumerable<DnsClient.Protocol.MxRecord> mxRecords = result.Answers.MxRecords();
                string[] recordInfo = new string[mxRecords.Count()];

                for (int i = 0; i < mxRecords.Count(); i++)
                {
                    string info = $"Domain Name: {domain}" +
                              $"\nTTL (Time-To-Live): {result.Answers[0].TimeToLive} seconds" +
                              $"\nRecord Type: {QueryType.MX}" +
                              $"\nPreference: {mxRecords.ElementAt(i).Preference}" +
                              $"\nMail Server: {mxRecords.ElementAt(i).Exchange}";
                    recordInfo[i] = info;
                }

                return recordInfo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Could not get mx records", ex);
            }
        }
    }
}
