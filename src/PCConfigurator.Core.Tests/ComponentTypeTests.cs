using NUnit.Framework;
using System;

namespace PCConfigurator.Core.Tests
{
    public class ComponentTypeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_ThrowsOnNullName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new ComponentType(null);
            });
        }

        [Test]
        public void Constructor_ThrowsOnEmptyName()
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                new ComponentType(string.Empty);
            });
        }

        [Test]
        public void Constructor_NameIsSetCorrectly()
        {
            var expectedName = "CPU";

            var componentType = new ComponentType(expectedName);

            Assert.AreEqual(expectedName, componentType.Name);
        }
    }
}