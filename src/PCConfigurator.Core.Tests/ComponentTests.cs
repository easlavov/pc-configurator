namespace PCConfigurator.Core.Tests
{
    using System;

    using NUnit.Framework;

    public class ComponentTests
    {
        [Test]
        public void Constructor_ThrowsOnNullComponentType()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Component(1, null, "GTX 960", 100);
            });
        }

        [Test]
        public void Constructor_ThrowsOnNullName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Component(1, new ComponentType(1, "GPU"), null, 100);
            });
        }

        [Test]
        public void Constructor_ThrowsOnEmptyName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Component(1, new ComponentType(1, "GPU"), string.Empty, 100);
            });
        }

        [Test]
        public void Constructor_ThrowsOnNegativePrice()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new Component(1, new ComponentType(1, "GPU"), "GTX 960", -100);
            });
        }
    }
}
