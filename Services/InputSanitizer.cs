using System.Text.RegularExpressions;

namespace SafeVault.Services {
    public static class InputSanitizer {
        public static string Sanitize(string input) {
            // Remove special characters
            string cleaned = Regex.Replace(input, @"[<>\""'%;()&+]", "");

            // Remove dangerous SQL keywords (case-insensitive)
            string[] keywords = { "DROP", "SELECT", "INSERT", "DELETE", "UPDATE", "EXEC", "UNION", "--" };
            foreach (var keyword in keywords) {
                cleaned = Regex.Replace(cleaned, keyword, "", RegexOptions.IgnoreCase);
            }

            return cleaned;
        }
    }
}