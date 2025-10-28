using NUnit.Framework;

namespace SafeVault.Tests {
    [TestFixture]
    public class SampleTest {
        [SetUp]
        public void Setup() {
            // Optional setup logic
        }

        [Test]
        public void AlwaysPasses() {
            Assert.That(true, Is.True);
        }
    }
}