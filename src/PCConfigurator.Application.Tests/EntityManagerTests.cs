namespace PCConfigurator.Application.Tests
{
    using System;
    using System.Linq;

    using PCConfigurator.Application.Repositories;
    using PCConfigurator.Core;

    using FakeItEasy;
    using NUnit.Framework;

    public class EntityManagerTests
    {
        private Repository<ComponentType> repository;

        [SetUp]
        public void Setup()
        {
            repository = A.Fake<Repository<ComponentType>>();

            var componentTypes = new[]
            {
                new ComponentType(1, "CPU"),
                new ComponentType(2, "GPU"),
            }.AsQueryable();

            A.CallTo(() => repository.GetAll()).Returns(componentTypes);
        }

        [Test]
        public void Constructors_ThrowsOnNullRepository()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new EntityManager<ComponentType>(null);
            });
        }

        [Test]
        public void LoadAll_ReturnsCorrectCountOf()
        {
            var manager = new EntityManager<ComponentType>(repository);

            var componentTypes = manager.LoadAll();

            Assert.AreEqual(2, componentTypes.Count());
        }
    }
}