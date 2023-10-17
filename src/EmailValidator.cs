using System.Text.RegularExpressions;

namespace Egen {
    public class EmailValidator {
        public static bool IsValidEmail(string email) {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
    }
}
