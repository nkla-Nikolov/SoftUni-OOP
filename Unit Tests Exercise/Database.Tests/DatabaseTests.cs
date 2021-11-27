using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1, 5)]
        [TestCase(1, 10)]
        [TestCase(1, 15)]
        public void CtorShouldStoreTheInitialElements(int start, int count)
        {
            var elements = Enumerable.Range(start, count).ToArray();

            Database data = new Database(elements);

            Assert.AreEqual(count, data.Count);
        }

        [Test]
        [TestCase(1, 17)]
        [TestCase(1, 20)]
        [TestCase(1, 25)]
        public void CtorShouldThrowExceptionWhenMoreThan16Elements(int start, int count)
        {
            var elements = Enumerable.Range(start, count).ToArray(); ;

            Assert.Throws<InvalidOperationException>(() => new Database(elements));
        }

        [Test]
        [TestCase(1, 5)]
        [TestCase(1, 10)]
        [TestCase(1, 15)]
        public void AddMethodShouldAddLessOrEqualTo16Elements(int start, int count)
        {
            var elements = Enumerable.Range(start, count).ToArray();

            Database data = new Database(elements);

            Assert.AreEqual(count, data.Count);
        }

        [Test]
        public void AddMethodShouldReturnExceptiIfMoreThan16ElementsAreInTheArray()
        {

            Database data = new Database();

            for (int i = 0; i < 16; i++)
            {
                data.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => data.Add(2));
        }

        [Test]
        public void RemoveMethodShouldReturnException()
        {
            Database data = new Database();

            Assert.IsTrue(data.Count == 0);
            Assert.Throws<InvalidOperationException>(() => data.Remove());
        }

        [Test]
        public void RemoveMethodShouldRemoveElementsSuccesful()
        {
            Database data = new Database();

            for (int i = 0; i < 5; i++)
            {
                data.Add(i);
            }

            data.Remove();
            Assert.AreEqual(4, data.Count);
        }

        [Test]
        [TestCase(10)]
        public void FetchMethodShouldReturnTheCopyOfTheOriginalArray(int count)
        {
            Database data = new Database();
            var copy = new int[count];

            for (int i = 0; i < count; i++)
            {
                data.Add(i);
                copy[i] = i;
            }

            Assert.That(() => data.Fetch(), Is.EqualTo(copy));
        }
    }
}