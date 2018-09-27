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
    [TestFixture] //еest framework attribute
    class WebDriver
    {
        private IWebDriver driver;

        [OneTimeSetUp]//один раз перед тетсуванням
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();//пуск браузера
            //driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);//неявне очікування
            driver.Manage().Window.Maximize();//розгортаю вікно
        }

        [OneTimeTearDown]//один раз після тетсуванням
        public void AfterAllMethods()
        {
            driver.Quit();//закриваємо браузер та сервер, Close - закриває табу але сервер працює
        }

        [SetUp] // перед кожним тестом
        public void SetUp()
        {
            driver.Navigate().GoToUrl("https://www.hotline.ua/");//перехід за посиланням
        }

        [TearDown]
        public void TearDown()//після кожного тесту
        {
            driver.Navigate().GoToUrl("https://www.hotline.ua/logout/");
        }

        [Test, Order(1)]//виконуватиметься 1-т >> по нумерації >> без нумерації по алфавіту
        public void LoginErrorTest()
        {
            //Arrange

            string expected = "Поле логін не може бути порожнім";

            //Act            
            driver.FindElement(By.ClassName("item-login")).Click();
            driver.FindElement(By.CssSelector("input.btn-graphite.btn-cell")).Click();
            Thread.Sleep(2000);//також очікування НЕ ВИКОРИСТОВУВАТИ
            string actual = driver.FindElement(By.CssSelector("div.errors")).Text;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test, Order(2)]//виконуватиметься 2-м
        public void LocalizationTest()
        {
            //Arrange
            driver.FindElement(By.XPath("//body[@id='page-index']/header/div/div/div/div/div/div[2]/div/div[3]/div/div/span[2]")).Click();
            string expected = "Гарячі новинки та хіти продажу";

            //Act
            string actual = driver.FindElement(By.CssSelector("p.h3")).Text;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SearchTest()
        {
            //Arrange
            IWebElement searchbox = driver.FindElement(By.Id("searchbox"));
            searchbox.Click();
            searchbox.Clear();
            searchbox.SendKeys("Туалетная бумага" + Keys.Enter);
            //browser.FindElement(By.Id("doSearch")).Click();

            //Act
            driver.FindElement(By.LinkText("Туалетная бумага Обухов (4820003830017)")).Click();

            //Assert
            Assert.IsTrue(SeleniumSetMethods.IsElementPresent(driver, By.CssSelector("img.img-product.busy")));
        }

        [Test]
        public void WebLogInTest()
        {
            //Arrange
            driver.FindElement(By.ClassName("item-login")).Click();
            IWebElement login = driver.FindElement(By.Name("login"));
            login.Click();
            login.Clear();
            login.SendKeys("doujohn3@meta.ua");

            IWebElement password = driver.FindElement(By.Name("password"));
            password.Click();
            password.Clear();
            password.SendKeys("doujohn3");
            password.Submit();

            //check
            driver.FindElement(By.ClassName("item-login")).Click();
            Assert.IsTrue(SeleniumSetMethods.IsElementPresent(driver, By.CssSelector("[href*='/logout/']")));
            driver.FindElement(By.CssSelector("[href*='/logout/']")).Click();
            Assert.IsFalse(SeleniumSetMethods.IsElementPresent(driver, By.CssSelector("[href*='/logout/']")));
            //#page-index > header > div.header > div > div > div.header-nav.cell-6 > div:nth-child(3) > div.item-compare > div > svg

        }
        //[Test] 
        //public void DropDownTest()
        //{
        //    //Arrange
        //    SeleniumSetMethods.ClickOperation(driver, "searchbox", "Id");   
        //SeleniumSetMethods.EnterText(driver, "searchbox", "Sony FDR-X3000R", "Id");
        //    SeleniumSetMethods.ClickOperation(driver, "doSearch", "Id");
        //    SeleniumSetMethods.SelectDropDown(driver, "search-type field", "all", "ClassName");
        //    SeleniumSetMethods.ClickOperation(driver, "searchbox", "Id");
        //    SeleniumSetMethods.EnterText(driver, "searchbox", "JBL Flip 4 Red (JBLFLIP4REDAM)", "Id");
        //    SeleniumSetMethods.ClickOperation(driver, "doSearch", "Id");
        //    string expected = "0 товарів";

        //    //Act
        //    string actual = driver.FindElement(By.CssSelector("p > span.bold")).Text;

        //    //Assert
        //    Assert.AreEqual(expected, actual);
    }
}