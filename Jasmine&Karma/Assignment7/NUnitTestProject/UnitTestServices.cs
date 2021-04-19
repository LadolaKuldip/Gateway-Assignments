using NUnit.Framework;
using Services;
using System;
using System.Collections;
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

        /// <summary>
        /// Testing of while loop
        /// </summary>
        /// <param name="number"></param>
        /// <param name="expected"></param>
        
        [TestCase(19, true)]
        [TestCase(80, false)]
        [TestCase(37, true)]
        public void CheckPrimeNumber_Test(int number, bool expected)
        {
            // Act
            var result = _service.CheckPrimeNumber(number);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Testing of switch case
        /// </summary>
        /// <param name="day"></param>
        /// <param name="expected"></param>
        
        [TestCase(1, "monday")]
        [TestCase(7, "sunday")]
        [TestCase(3, "wednesday")]
        [TestCase(0, "invalid")]
        public void GetDayOfWeek_Test(int day, string expected)
        {
            // Act
            var result = _service.GetDayOfWeek(day);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Testing of if-else
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expected"></param>
        
        [TestCase(100, "positive")]
        [TestCase(-31, "negative")]
        [TestCase(0, "zero")]
        public void CheckNumber_Test(int value, string expected)
        {
            // Act
            var result = _service.CheckNumber(value);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Testing of for-each
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        
        [TestCaseSource(typeof(TestDataofIntArray), nameof(TestDataofIntArray.TestCases))]
        public int FindSumOfOddNumbers_Test(List<int> values)
        {
            // Act
            var result = _service.FindSumOfOddNumbers(values);

            // Assert
            return result;
        }

        /// <summary>
        /// Testing of for loop
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="expected"></param>
       
        [TestCase(11, 2 ,22)]
        [TestCase(5, 7, 35)]
        public void Multiplication_Test(int first, int second, int expected)
        {
            // Act
            var result = _service.Multiplication(first, second);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        /// <summary>
        /// Testing of exception handling
        /// </summary>
        
        [Test]
        public void Division_Test()
        {
            // Act, Assert
            Assert.Throws<InvalidOperationException>(() => _service.Division(1, 0))
                .Message.Equals("can not divide by zero");
        }

        /// <summary>
        /// Testing of exception handling
        /// </summary>
        
        [Test]
        public void MethodNotImplemented_Test()
        {
            // Act, Assert
            Assert.Throws<NotImplementedException>(() => _service.MethodNotImplemented());
        }

        /// <summary>
        /// Testing of exception handling
        /// </summary>

        [Test]
        public void FindValue_Test()
        {
            // Arrange
            int index = 11;

            // Act, Assert
            Assert.Throws<IndexOutOfRangeException>(() => _service.FindValue(index));
        }

        /// <summary>
        /// Testing of EquivalentTo & EqualTo Methods
        /// </summary>

        [Test]
        public void EqualMethod_Test()
        {
            // Arrange
            var a = new List<int> { 1, 2 };
            var b = new List<int> { 2, 1 };

            // Assert
            Assert.That(a, Is.EqualTo(b)); // fails
            Assert.That(a, Is.EquivalentTo(b)); // succeeds
        }

        /// <summary>
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
    }

    public class TestDataofIntArray
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new List<int> { 1, 2, 3, 4, 5, 22, 8}).Returns(9);
                yield return new TestCaseData(new List<int> { 11, 7, 29, 0 }).Returns(47);
            }
        }
    }
}