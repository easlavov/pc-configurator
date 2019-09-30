namespace PCConfigurator.Core.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class ConfigurationTests
    {
        [Test]
        public void Constructor_ThrowsOnNullName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Configuration(1, null, new List<Component>());
            });
        }

        [Test]
        public void Constructor_ThrowsOnEmptyName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Configuration(1, string.Empty, new List<Component>());
            });
        }

        [Test]
        public void Constructor_ThrowsOnNullComponents()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Configuration(1, "My Configuration", null);
            });
        }

        [Test]
        public void TotalPrice_ReturnsSumOfComponentPrices()
        {
            var components = new[]
            {
                new Component(1, new ComponentType(1, "CPU"), "FX-8150", 150),
                new Component(2, new ComponentType(2, "GPU"), "GTX 960", 200),
            };

            var configuration = new Configuration(1, "My Configuration", components);

            Assert.AreEqual(350, configuration.TotalPrice);
        }
    }
}
