using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Pages
{
    public class LoginPage:BaseClass
    {
        #region Locators
        By username = By.Id("user-name");
        By password = By.Id("password");
        By btn = By.Id("login-button");
        #endregion

        #region Methods
        public void sendUserName()
        {
           
            driver.FindElement(username).SendKeys("standard_user");
        }
        public void sendInvalidUserName()
        {

            driver.FindElement(username).SendKeys("humnaanwar");
        }
        public void sendPassword()
        {
            driver.FindElement(password).SendKeys("secret_sauce");
        }
        public void clickOnLoginButton()
        {
            driver.FindElement(btn).Click();
        }
        #endregion
    }
}
