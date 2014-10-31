using System;
using System.Linq;
using DataAccess.Domain;
using NUnit.Framework;

namespace DataAccess.Tests
{
    [TestFixture]
    public class Database_should
    {
        [Test]
        public void add_data_to_database()
        {
            //// Arrange
            var sut = Database.Instance;
            var defaultCount = sut.ReadAll<TestEntity>().Count();
            var data = new TestEntity();
            //// Act
            sut.Write(data);

            //// Assert
            Assert.That(sut.ReadAll<TestEntity>().Count(), Is.EqualTo(defaultCount+1));
        }

        [Test]
        public void read_data_from_database()
        {
            //// Arrange
            var sut = Database.Instance;
            var data = new TestEntity();
            //// Act
            sut.Write(data);
            var result = sut.Read<TestEntity>(data.Id);
            //// Assert
            Assert.That(result.Id, Is.EqualTo(data.Id));
        }
    }

    public class TestEntity : IEntity
    {
        public TestEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
