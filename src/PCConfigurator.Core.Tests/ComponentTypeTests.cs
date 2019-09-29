namespace PCConfigurator.Core.Tests
{
    using System;

    using NUnit.Framework;

    public class ComponentTypeTests
    {
        [Test]
        public void Constructor_ThrowsOnNullName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new ComponentType(1, null);
            });
        }

        [Test]
        public void Constructor_ThrowsOnEmptyName()
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                new ComponentType(1, string.Empty);
            });
        }

        [Test]
        public void Constructor_NameIsSetCorrectly()
        {
            var expectedName = "CPU";

            var componentType = new ComponentType(1, expectedName);

            Assert.AreEqual(expectedName, componentType.Name);
        }
    }
}