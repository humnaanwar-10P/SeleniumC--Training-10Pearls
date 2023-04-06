using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Pages;

namespace Training.Tests
{
    [TestClass]
    public class Login : BaseClass
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
        public void loginWithValidCreds() 
        {
            LoginPage loginPage = new LoginPage();
            test = extent.CreateTest("Login With Valid Creds", "User is able to login");

            loginPage.sendUserName();
            test.Log(Status.Info, "Sending Username");
            
            loginPage.sendPassword();
            test.Log(Status.Info, "Sending Password");
           
            loginPage.clickOnLoginButton();
            test.Log(Status.Info, "Clicking on Login button");

            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url);
            test.Log(Status.Pass,"Assertion Passed, User logged in successfully");
            //Assert.IsNotNull(driver.Url);

            string urll = driver.Url;
            string us = "standard_user";

            Console.WriteLine($"Hello! Welcome to {urll}! You have logged in successfully with username {us}.");


        }
        [TestMethod]
        public void loginWithInvalidCreds()
        {
            LoginPage loginPage = new LoginPage();
            test = extent.CreateTest("Login With Invalid Creds", "User shouldn't login");

            loginPage.sendInvalidUserName();
            test.Log(Status.Info, "Sending Invalid Username");

            loginPage.sendPassword();
            test.Log(Status.Info, "Sending Password");

            loginPage.clickOnLoginButton();
            test.Log(Status.Info, "Clicking on Login button");

            Assert.AreNotEqual("https://www.saucedemo.com/inventory.html", driver.Url);
            test.Log(Status.Pass, "Assertion Passed, User didnt login successfully");
            //Assert.IsNotNull(driver.Url);

        }
    }
}
