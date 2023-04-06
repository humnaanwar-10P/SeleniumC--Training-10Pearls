using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class BaseClass
    {
        public static IWebDriver driver;
      // public WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

        [TestInitialize]
        public void CreateDriver()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
            driver.Manage().Window.Maximize();
            
        }
/*
       [TestCleanup]
        public void CloseDriver()
        {
            driver.Close();
        }*/

    }
}
