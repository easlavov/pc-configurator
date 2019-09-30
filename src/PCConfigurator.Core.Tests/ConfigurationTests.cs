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
        public void Constructor_ThrowsOnComponentsWithSameComponentType()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var components = new[]
                {
                    new Component(1, new ComponentType(1, "CPU"), "FX-8150", 150),
                    new Component(2, new ComponentType(2, "GPU"), "GTX 960", 200),
                    new Component(2, new ComponentType(2, "GPU"), "GTX 1080", 500),
                };
                new Configuration(1, "My Configuration", components);
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

        [Test]
        public void Components_Setter_ThrowsOnComponentsWithSameComponentType()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var configuration = new Configuration(1, "My Configuration", new List<Component>());

                var components = new[]
                {
                    new Component(1, new ComponentType(1, "CPU"), "FX-8150", 150),
                    new Component(2, new ComponentType(2, "GPU"), "GTX 960", 200),
                    new Component(2, new ComponentType(2, "GPU"), "GTX 1080", 500),
                };

                configuration.Components = components;
            });
        }

        [Test]
        public void Components_Getter_ReturnsCorrectly()
        {
            var configuration = new Configuration(1, "My Configuration", new List<Component>());

            var components = new[]
            {
                new Component(1, new ComponentType(1, "CPU"), "FX-8150", 150),
                new Component(2, new ComponentType(2, "GPU"), "GTX 960", 200),
            };

            configuration.Components = components;

            var gotComponets = configuration.Components;

            Assert.AreEqual(components[0], gotComponets[0]);
            Assert.AreEqual(components[1], gotComponets[1]);
        }
    }
}
