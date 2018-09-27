using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Selenium_first_try
{
    class SeleniumSetMethods
    {
        //method for Enter Text(element,value,type)
        public static void EnterText(IWebDriver driver, string element, string value, string elementType)
        {
            if (elementType == "ID")
            {
                driver.FindElement(By.Id(element)).SendKeys(value);
            }
            if (elementType == "Name")
            {
                driver.FindElement(By.Name(element)).SendKeys(value);
            }
            //if (elementType == "ClassName")
            //{
            //    driver.FindElement(By.ClassName(element)).SendKeys(value);
            //}
        }

        //method for click operation
        public static void ClickOperation(IWebDriver driver, string element, string elementType)
        {
            if (elementType == "ID")
            {
                driver.FindElement(By.Id(element)).Click();
            }
            if (elementType == "Name")
            {
                driver.FindElement(By.Name(element)).Click();
            }
            //if (elementType == "ClassName")
            //{
            //    driver.FindElement(By.ClassName(element)).Click();
            //}
        }

        //Selecting a drop down control
        public static void SelectDropDown(IWebDriver driver, string element, string value, string elementType)
        {
            if (elementType == "ID")
            {
                new SelectElement(driver.FindElement(By.Id(element))).SelectByText(value);//only in "using OpenQA.Selenium.Support.UI;" need to install Selenium.Support package
            }
            if (elementType == "Name")
            {
                new SelectElement(driver.FindElement(By.Name(element))).SelectByText(value);
            }
            //if (elementType == "ClassName")
            //{
            //    new SelectElement(driver.FindElement(By.ClassName(element))).SelectByText(value);
            //}
        }

        //method for element present check
        public static bool IsElementPresent(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
