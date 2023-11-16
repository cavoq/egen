using System.Net;
using Egen.Config;

namespace Egen
{
    public static class Utils
    {
        public static void SaveToFile(string content, string filePath)
        {
            if (filePath.Equals(""))
            {
                throw new FileNotFoundException("Error: File path invalid");
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

        public static string[] ReadListFromFile(string? filePath)
        {
            try
            {
                if (!File.Exists(filePath) || filePath == null)
                {
                    throw new FileNotFoundException($"File not found: {filePath}");
                }
                return File.ReadAllLines(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Could not read file", ex);
            }
        }

        public static string ReadCharactersFromFile(string? filePath)
        {
            try
            {
                if (!File.Exists(filePath) || filePath == null)
                {
                    throw new FileNotFoundException($"File not found: {filePath}");
                }
                return File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Could not read file", ex);
            }
        }
    }
}
