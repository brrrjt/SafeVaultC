using System.Data.SqlClient;

namespace SafeVault.Services {
    public class UserService {
        private readonly string _connectionString;

        public UserService(string connectionString) {
            _connectionString = connectionString;
        }

        public bool Authenticate(string username, string password) {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("SELECT PasswordHash FROM Users WHERE Username = @username", conn);
            cmd.Parameters.AddWithValue("@username", InputSanitizer.Sanitize(username));
            conn.Open();
            var hash = cmd.ExecuteScalar()?.ToString();
            return hash != null && AuthService.VerifyPassword(password, hash);
        }

        public string GetUserRole(string username) {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("SELECT Role FROM Users WHERE Username = @username", conn);
            cmd.Parameters.AddWithValue("@username", InputSanitizer.Sanitize(username));
            conn.Open();
            return cmd.ExecuteScalar()?.ToString() ?? "user";
        }
    }
}