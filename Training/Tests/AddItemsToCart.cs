using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Pages;

namespace Training.Tests
{
    [TestClass]
    public class AddItemsToCart : BaseClass
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
        public void AddOneProductToCart()
        {


            //LoginSteps

            Pages.LoginPage loginPage = new Pages.LoginPage();

            loginPage.sendUserName();
            loginPage.sendPassword();
            loginPage.clickOnLoginButton();

            //TestSteps

            test = extent.CreateTest("a.Add an item to cart and validate", "");

            AddItemsToCartPage addToCart = new AddItemsToCartPage();

            addToCart.AddBackPackToCart();
            test.Log(Status.Info, "BackPack successfully added to the cart");
            addToCart.clickCart();
            test.Log(Status.Info, "Cart page opened");

            test.Log(Status.Info, "Performing assertion");
            IWebElement productName = driver.FindElement(By.ClassName("inventory_item_name"));
            Assert.AreEqual("Sauce Labs Backpack", productName.Text, "Value does not match");
            test.Log(Status.Pass);

            string urll = driver.Url;
            string us = "standard_user";

            Console.WriteLine($"Hello! Welcome to {urll}! You have logged in with username {us}. You have added 1 items to cart.");

        }

        [TestMethod]
        public void AddTwoProductsToCart()
        {
            AddItemsToCartPage addToCart = new AddItemsToCartPage();
            test = extent.CreateTest("b.Add two items to cart and validate", "");

            //LoginSteps

            LoginPage loginPage = new LoginPage();
            loginPage.sendUserName();
            loginPage.sendPassword();
            loginPage.clickOnLoginButton();

            //TestSteps

            addToCart.AddBackPackToCart();
            test.Log(Status.Info, "BackPack successfully added to the cart");

            addToCart.clickCart();
            test.Log(Status.Info, "BackPack displaying on Cart page");

            addToCart.clickContinueShopping();
            test.Log(Status.Info, "Continue Shopping button is working");

            addToCart.AddLightsToCart();
            test.Log(Status.Info, "Lights successfully added to the cart");

            addToCart.clickCart();
            test.Log(Status.Info, "Cart page opened");

            test.Log(Status.Info, "Performing assertion");

            string expectedProduct1 = "Sauce Labs Backpack";
            IWebElement actualProduct1 = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[1]/div[3]/div[2]/a/div"));

            string expectedProduct2 = "Sauce Labs Bike Light";
            IWebElement actualProduct2 = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[1]/div[4]/div[2]/a/div"));

            bool testPassed = true;


            // Assert

            try
            {
                Assert.AreEqual(expectedProduct1, actualProduct1.Text);
                test.Log(Status.Pass, "Assertion 1: Expected Product1 = " + expectedProduct1 + ", Actual Product1 = " + actualProduct1.Text);
            }
            catch (AssertionException e)
            {
                testPassed = false;
                test.Log(Status.Fail, "Assertion 1: Expected Product1 = " + expectedProduct1 + ", Actual Product1 = " + actualProduct1.Text);
                test.Fail(e.Message);
            }

            try
            {
                Assert.AreEqual(expectedProduct2, actualProduct2.Text);
                test.Log(Status.Pass, "Assertion 2: Expected Product2 = " + expectedProduct2 + ", Actual Product2 = " + actualProduct2.Text);
            }
            catch (AssertionException e)
            {
                testPassed = false;
                test.Log(Status.Fail, "Assertion 2: Expected Product2 = " + expectedProduct2 + ", Actual Product2 = " + actualProduct2.Text);
                test.Fail(e.Message);
            }

            Assert.IsTrue(testPassed);
            test.Log(Status.Pass, "All assertions passed successfully.");

            string urll = driver.Url;
            string us = "standard_user";

            Console.WriteLine($"Hello! Welcome to {urll}! You have logged in with username {us}. You have added 1 items to cart.");




        }


        [TestMethod]
        public void AddThreeProductsToCart()
        {
            AddItemsToCartPage addToCart = new AddItemsToCartPage();
            test = extent.CreateTest("c.	Add three items to cart, remove the second item added to cart and validate", "");

            //LoginSteps

            LoginPage loginPage = new LoginPage();
            loginPage.sendUserName();
            loginPage.sendPassword();
            loginPage.clickOnLoginButton();

            //TestSteps

            addToCart.AddBackPackToCart();
            test.Log(Status.Info, "BackPack successfully added to the cart");

            addToCart.clickCart();
            test.Log(Status.Info, "BackPack displaying on Cart page");

            addToCart.clickContinueShopping();
            test.Log(Status.Info, "Continue Shopping button is working");

            addToCart.AddLightsToCart();
            test.Log(Status.Info, "Lights successfully added to the cart");
            addToCart.AddShirtToCart();
            test.Log(Status.Info, "T-shirt successfully added to the cart");

            addToCart.clickCart();
            test.Log(Status.Info, "Cart page opened");

            addToCart.RemoveLightsFromCart();
            test.Log(Status.Info, "Lights successfully removed from the cart");


            test.Log(Status.Info, "Performing assertion");

            bool isElementPresent = IsElementPresentByXPath("myElementId");

            Assert.IsFalse(isElementPresent, "Web element with ID 'myElementId' should not be present on the page.");

            // Log the assertion result in the extent report
            var status = isElementPresent ? Status.Fail : Status.Pass;
            test.Log(status, "Assertion Passed: Lights are successfully removed from the cart");

            string urll = driver.Url;
            string us = "standard_user";

            Console.WriteLine($"Hello! Welcome to {urll}! You have logged in with username {us}. You have added 1 items to cart.");


        }
        private bool IsElementPresentByXPath(string elementId)
        {
            // Check if the web element is present on the page by ID
            try
            {
                driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[1]/div[3]/div[2]/a/div"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        [TestMethod]
        public void RemoveAllProductsFromCart()
        {
            AddItemsToCartPage addToCart = new AddItemsToCartPage();
            test = extent.CreateTest("d.	Remove all the elements added to cart and verify", "");

            //LoginSteps

            LoginPage loginPage = new LoginPage();
            loginPage.sendUserName();
            loginPage.sendPassword();
            loginPage.clickOnLoginButton();

            //TestSteps

            addToCart.AddBackPackToCart();
            test.Log(Status.Info, "BackPack successfully added to the cart");

            addToCart.clickCart();
            test.Log(Status.Info, "BackPack displaying on Cart page");

            addToCart.clickContinueShopping();
            test.Log(Status.Info, "Continue Shopping button is working");

            addToCart.AddLightsToCart();
            test.Log(Status.Info, "Lights successfully added to the cart");
            addToCart.AddShirtToCart();
            test.Log(Status.Info, "T-shirt successfully added to the cart");

            addToCart.clickCart();
            test.Log(Status.Info, "Cart page opened");

            addToCart.RemoveLightsFromCart();
            test.Log(Status.Info, "Lights successfully removed from the cart");

            addToCart.RemoveBackpackFromCart();
            test.Log(Status.Info, "BackPack successfully removed from the cart");

            addToCart.RemoveTshirtFromCart();
            test.Log(Status.Info, "T-Shirt successfully removed from the cart");

            test.Log(Status.Info, "Performing assertion");

         

            //Find the elements using Selenium WebDriver
            var element1 = driver.FindElements(By.XPath("/html/body/div/div/div/div[2]/div/div[1]/div[3]/div[2]/a/divv"));
            var element2 = driver.FindElements(By.XPath("/html/body/div/div/div/div[2]/div/div[1]/div[4]/div[2]/a/div"));
            var element3 = driver.FindElements(By.XPath("/html/body/div/div/div/div[2]/div/div[1]/div[5]/div[2]/a/div"));

            //Assert that the elements are not present on the webpage and log status message to Extent report
            Assert.IsFalse(element1.Any(), "Element 1 should not be present on the webpage");
            test.Log(Status.Info, "Asserted that Element 1 is not present on the webpage");
            Assert.IsFalse(element2.Any(), "Element 2 should not be present on the webpage");
            test.Log(Status.Info, "Asserted that Element 2 is not present on the webpage");
            Assert.IsFalse(element3.Any(), "Element 3 should not be present on the webpage");
            test.Log(Status.Info, "Asserted that Element 3 is not present on the webpage");

            string urll = driver.Url;
            string us = "standard_user";

            Console.WriteLine($"Hello! Welcome to {urll}! You have logged in with username {us}. You have added no items to cart.");



        }
    }
}