using Moq;
using NUnit.Framework;
using Project.Controllers;
using Project.Repository;
using System;

namespace NUnitAssignment9
{
    class MockTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test using Mock
        /// </summary>
        [Test]
        public void TestMethod1()
        {
            // Arrange
            var author = new Mock<IAuthor>();

            // Act
            author.SetupGet(p => p.Id).Returns(1);
            author.SetupGet(p => p.FirstName).Returns("Kuldip");
            author.SetupGet(p => p.LastName).Returns("Ladola");

            // Assert
            Assert.AreEqual("Kuldip", author.Object.FirstName);
            Assert.AreEqual("Ladola", author.Object.LastName);
        }

        /// <summary>
        /// Test using Mock
        /// </summary>
        [Test]
        public void TestMethod2()
        {
            // Arrange
            var mock = new Mock<IGetDataRepository>();
            mock.Setup(p => p.GetNameById(1)).Returns("Jignesh");
            HomeController home = new HomeController(mock.Object);

            // Act
            string result = home.GetNameById(1);

            // Assert
            Assert.AreEqual("Jignesh", result);
        }

        /// <summary>
        /// Test using Mock
        /// </summary>
        [Test]
        public void TestMethod3()
        {
            // Arrange
            var mockObj = new Mock<Article>();
            mockObj.Setup(x => x.GetPublicationDate(It.IsAny<int>())).Returns((int x) => DateTime.Now.Date);

            // Act
            var result = mockObj.Object.GetPublicationDate(110);

            // Assert
            Assert.AreEqual(DateTime.Now.Date, result);
        }

        /// <summary>
        /// Test using Mock
        /// </summary>
        [Test]
        public void TestMethod4()
        {
            // Arrange
            var mock = new Mock<IGetDataRepository>();
            string[] array = { "Kuldip", "Parth" };
            mock.Setup(p => p.GetAll()).Returns(array);
            HomeController home = new HomeController(mock.Object);

            // Act
            var result = home.GetAll();

            // Assert
            Assert.That(result, Has.Length.EqualTo(2).And.SameAs(array));
        }

        /// <summary>
        /// Test using Mock
        /// </summary>
        [Test]
        public void TestMethod5()
        {
            // Arrange
            var mockObj = new Mock<Article>();
            mockObj.Setup(x => x.GetTotalArticles(It.IsAny<int>())).Returns(3);

            // Act
            var result = mockObj.Object.GetTotalArticles(12);

            // Assert
            Assert.That(result, Is.GreaterThanOrEqualTo(0));
        }
    }
}
