using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace NUnitTestProject
{
    public class OrderedTestAttribute : Attribute
    {
        public int Order { get; set; }

        public OrderedTestAttribute(int order)
        {
            Order = order;
        }
    }

    public class TestStructure
    {
        public Action Test;
    }

   
    [TestFixture]
    public class ControllingTestOrder
    {
        private int x=10 , y =4;

        [SetUp]
        public void SetUp()
        {
        }

        [OrderedTest(0)]
        public void Test0()
        {
            int result = x + y;
            Assert.AreEqual(result, 14);
        }

        [OrderedTest(2)]
        public void Test2()
        {
            int result = x - y;
            Assert.AreEqual(result, 6);
        }


        [OrderedTest(1)]
        public void Test1()
        {
            int result = x * y;
            Assert.AreEqual(result, 40);
        }

        [OrderedTest(3)]
        public void Test3()
        {
            int result = (int)( x / y );
            Assert.AreEqual(result, 2);
        }


        [TestCaseSource(sourceName: "TestSource")]
        public void MyTest(TestStructure test)
        {
            test.Test();
        }

        public static IEnumerable<TestCaseData> TestSource
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                Dictionary<int, List<MethodInfo>> methods = assembly
                    .GetTypes()
                    .SelectMany(x => x.GetMethods())
                    .Where(y => y.GetCustomAttributes().OfType<OrderedTestAttribute>().Any())
                    .GroupBy(z => z.GetCustomAttribute<OrderedTestAttribute>().Order)
                    .ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());

                foreach (var order in methods.Keys.OrderBy(x => x))
                {
                    foreach (var methodInfo in methods[order])
                    {
                        MethodInfo info = methodInfo;
                        yield return new TestCaseData(
                            new TestStructure
                            {
                                Test = () =>
                                {
                                    object classInstance = Activator.CreateInstance(info.DeclaringType, null);
                                    info.Invoke(classInstance, null);
                                }
                            }).SetName(methodInfo.Name);
                    }
                }

            }
        }
    }
}
