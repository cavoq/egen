namespace Egen
{
    public static class Utils
    {
        public static void SaveToFile(string content, string filePath)
        {
            if (filePath.Equals(""))
            {
                throw new Exception("Error: File path invalid");
            }

            try
            {
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Could not safe content to file", ex);
            }
        }
    }
}
