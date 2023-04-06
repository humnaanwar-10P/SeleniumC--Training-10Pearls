using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Training
{
    [TestClass]
    public class UnitTest1 : BaseClass
    {
       
        [TestMethod]
        public void Assignment2()
        {
            //us= username
            //ps= password
            //btn= /html/body/div[49]/form/div[3]/div[3]/input

            By username = By.Id("user-name");
            By password = By.Id("password");
            By btn = By.Id("login-button");


            string us = "standard_user";
            driver.FindElement(username).SendKeys(us);
            driver.FindElement(password).SendKeys("secret_sauce");
            driver.FindElement(btn).Click();

           // Thread.Sleep(5000);

            string urll = driver.Url;

            Console.WriteLine("Your username: " + us);
            Console.WriteLine("This is current url: " + urll);

        }
    }
}