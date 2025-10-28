using NUnit.Framework;
using SafeVault.Services;

namespace SafeVault.Tests {
    [TestFixture]
    public class TestInputValidation {
        [Test]
        public void TestForSQLInjection() {
            string input = "'; DROP TABLE Users;--";
            string sanitized = InputSanitizer.Sanitize(input);
            Assert.That(sanitized.Contains("DROP"), Is.False);
        }

        [Test]
        public void TestForXSS() {
            string input = "<script>alert('XSS')</script>";
            string sanitized = InputSanitizer.Sanitize(input);
            Assert.That(sanitized.Contains("<script>"), Is.False);
        }
    }
}