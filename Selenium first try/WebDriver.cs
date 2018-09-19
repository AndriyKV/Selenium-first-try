using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace Selenium_first_try
{
    [TestFixture]
    class WebDriver
    {
        private IWebDriver browser;

        [OneTimeSetUp]//один раз перед тетсуванням
        public void BeforeAllMethods()
        {
            browser = new ChromeDriver();//пуск браузера
            //driver = new FirefoxDriver();
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);//неявне очікування
            browser.Manage().Window.Maximize();//розгортаю вікно
        }

        [OneTimeTearDown]//один раз після тетсуванням
        public void AfterAllMethods()
        {
            browser.Quit();//закриваємо браузер та сервер, Close - закриває табу але сервер працює
        }

        [SetUp] // перед кожним тестом
        public void SetUp()
        {
            browser.Navigate().GoToUrl("https://www.hotline.ua/");//перехід за посиланням
        }

        [TearDown]
        public void TearDown()//після кожного тесту
        {
        }

        [Test]
        public void LoginErrorTest()
        {
            //Arrange
            browser.FindElement(By.ClassName("item-login")).Click();
            browser.FindElement(By.CssSelector("input.btn-graphite.btn-cell")).Click();
            

            //Act
            Thread.Sleep(2000);//також очікування НЕ ВИКОРИСТОВУВАТИ

            //Assert
            Assert.AreEqual("Поле логин не может быть пустым", browser.FindElement(By.CssSelector("div.errors")).Text);
        }
    }
}
