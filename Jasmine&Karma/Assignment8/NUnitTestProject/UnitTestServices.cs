using FluentAssertions;
using NUnit.Framework;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUnitTestProject
{
    public class Tests
    {
        private Service _service;

        [SetUp]
        public void Setup()
        {
            _service = new Service();
        }


        /// Testing Async Method
        /// </summary>
        /// <returns></returns>

        [Test]
        public async Task GetStringArray_Test()
        {
            // Act
            var result = await _service.GetStringArray();

            // Assert
            Assert.That(result, Has.All.With.Length.EqualTo(3).And.All.Contains("a"));
        }

        /// <summary>
        /// Testing Async Method
        /// </summary>
        /// <returns></returns>

        [Test]
        public async Task GetUsersData_Test()
        {
            // Act
            var result = await _service.GetUsersData();

            // Assert
            Assert.That(result, Has
             .Length.EqualTo(3)
             .And.Exactly(1).Property("Id").EqualTo(1)
             .And.Some.Property("Address").Null
             .And.All.Property("Name").Not.Null
             .And.All.Property("Email").Contains('@')
             .And.No.Property("Id").LessThanOrEqualTo(0));
        }

        [Test]
        public void GetTable_Test()
        {
            int number = 5;

            int[] data = _service.GetTable(number);

             data.Should().NotBeEmpty()
            .And.HaveCount(10)
            .And.AllBeOfType(typeof(int))
            .And.StartWith(number*1)
            .And.EndWith(number*10);
        }
        
        [Test]
        public void GetName_Test()
        {
            string value = _service.GetName();

            value.Should().NotBeNullOrWhiteSpace()
            .And.Contain("kuldip")
            .And.Contain("l", Exactly.Thrice())
            .And.Be("kuldip ladola")
            .And.NotBe("ladola kuldip")
            .And.BeOneOf(
                "kuldip ladola",
                "ladola kuldip"
            );
        }




       
    }
}