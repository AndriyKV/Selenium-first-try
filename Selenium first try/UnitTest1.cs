using System;
using System.Windows;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework; //встановлена через нагіт потрібна бібліотека

namespace Selenium_first_try
{
    //[TestClass]
    //public class UnitTest1
    //{
    //    [TestMethod]
    //    public void TestMethod1()
    //    {

    //        Console.WriteLine("start");
    //        //int i = 0;
    //        double i = 0;
    //        Console.WriteLine("(i+1)/i= " + (i + 1) / i);
    //        Console.WriteLine("done");
    //        //throw new Exception("ha-ha-ha");
    //    }
    //}
    [TestFixture]//структура перед класом
    public class UnitTest1
    //[Parallelizable(ParallelScope.All)]
    {
        [OneTimeSetUp]//виконується раз перед тестом / можему тут вказати прекондішн
        public void BeforeAllMethods()
        {
            Console.WriteLine("[OneTimeSetUp] BeforeAllMethods()");
            //MessageBox.Show("[OneTimeSetUp] BeforeAllMethods()", "info",
            //MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [OneTimeTearDown]//виконується раз після тесту
        public void AfterAllMethods()
        {
            Console.WriteLine("[OneTimeTearDown] AfterAllMethods()");
            //MessageBox.Show("[OneTimeTearDown] AfterAllMethods()", "info",
            //MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [SetUp]//перед кожним методом
        public void SetUp()
        {
            Console.WriteLine("[SetUp] SetUp()");
        }

        [TearDown]//після кожного методу
        public void TearDown()
        {
            Console.WriteLine("[TearDown] TearDown()");
        }

        //[Test] //перевірка методу натомість майкрософтівського [TestMethod]
        public void TestMethod1(
            [Values("Hello", "World")]  string s,//змінна с отримує спочатку хело а на наступний тест ворлд 
            [Random(1, 10, 5)] int x)//ікс від 1 до 10 5 разів випадкове число
        {
            Console.WriteLine("Ok, s=" + s + " x=" + x);//відпрацює 10 разів
        }

        //[TestCase(5, ExpectedResult = true)]
        //[TestCase(-15, ExpectedResult = false)]
        public bool TestMethod2(int x)
        { return x > 0; }

        // DataProvider
        private static readonly object[] ConverterData =
        {  new object[] { 65, 'A' },
            new object[] { 97, 'a' },
            new object[] { 98, 'b' }
        };
        //[TestCase(65, 'A')]
        //[TestCase(97, 'a')]
        //[Test, TestCaseSource(nameof(ConverterData))]
        public void TestMethod3(int x, char c)
        {
            char expexted = c;
            char actual = (char)x;
            Assert.AreEqual(expexted, actual);
        }


    }
}
