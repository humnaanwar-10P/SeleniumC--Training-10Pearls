using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using Training.Pages;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

namespace Training.Tests
{
    [TestClass]
    public class Logout : BaseClass
    {
        public TestContext TestContext { get; set; }
        public static ExtentTest test;
        public static ExtentReports extent;


        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var htmlReporter = new ExtentHtmlReporter("C:\\Users\\humna.anwar\\source\\repos\\Training\\Training\\ExtentReport\\");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            extent.Flush();
        }

        [TestMethod]
        public void testLogout()
        {
            LogoutPage logoutPage = new LogoutPage();
            test = extent.CreateTest("Logout and validate", "");

            //LoginSteps

            LoginPage loginPage = new LoginPage();
            loginPage.sendUserName();
            loginPage.sendPassword();
            loginPage.clickOnLoginButton();

            //TestSteps

            LogoutPage logout = new LogoutPage();

            // Set up the wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Wait for an element to be visible on the page
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("add-to-cart-sauce-labs-onesie")));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable);



            logout.openSidemenu();
            test.Log(Status.Info, "Sidemenu opened");

            logout.clickOnLogout();
            test.Log(Status.Info, "Clicking on Logout button");

            IWebElement loginButton = driver.FindElement(By.Id("login-button"));
            bool isLoginButtonPresent = loginButton.Displayed;

            Assert.IsTrue(isLoginButtonPresent, "Login button is not present");

            if (isLoginButtonPresent)
            {
                test.Log(Status.Pass, "Logout successful. Login button is present.");
            }
            else
            {
                test.Log(Status.Fail, "Logout unsuccessful. Login button is not present.");
            }

            string urll = driver.Url;
            string us = "standard_user";

            Console.WriteLine($"Hello! Welcome to {urll}! You logged in with username {us}. Logout Test Passed");

        }
    }
}
