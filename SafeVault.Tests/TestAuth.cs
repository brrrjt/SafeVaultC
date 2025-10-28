using NUnit.Framework;
using SafeVault.Services;

namespace SafeVault.Tests {
    [TestFixture]
    public class TestAuth {
        [Test]
        public void TestInvalidLogin() {
            string hash = AuthService.HashPassword("securepass");
            bool result = AuthService.VerifyPassword("wrongpass", hash);
            Assert.That(result, Is.False);
        }

        [Test]
        public void TestUnauthorizedAccess() {
            bool result = RBAC.IsAuthorized("user", "admin");
            Assert.That(result, Is.False);
        }
    }
}