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
                new Configuration(1, null, new List<ConfigurationComponent>());
            });
        }

        [Test]
        public void Constructor_ThrowsOnEmptyName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Configuration(1, string.Empty, new List<ConfigurationComponent>());
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
                new ConfigurationComponent(new Component(1, new ComponentType(1, "CPU"), "FX-8150", 150), 1),
                new ConfigurationComponent(new Component(2, new ComponentType(2, "GPU"), "GTX 960", 200), 2)
            };

            var configuration = new Configuration(1, "My Configuration", components);

            Assert.AreEqual(550, configuration.TotalPrice);
        }        

        [Test]
        public void Components_Getter_ReturnsCorrectly()
        {
            var configuration = new Configuration(1, "My Configuration", new List<ConfigurationComponent>());

            var components = new[]
            {
                new ConfigurationComponent(new Component(1, new ComponentType(1, "CPU"), "FX-8150", 150), 1),
                new ConfigurationComponent(new Component(2, new ComponentType(2, "GPU"), "GTX 960", 200), 1)
            };

            configuration.ConfigurationComponents = components;

            var gotComponets = configuration.ConfigurationComponents;

            Assert.AreEqual(components[0], gotComponets[0]);
            Assert.AreEqual(components[1], gotComponets[1]);
        }
    }
}
