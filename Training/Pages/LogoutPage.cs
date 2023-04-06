using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Training.Pages
{
    public class LogoutPage : BaseClass
    {
        By sidemenu = By.Id("react-burger-menu-btn");
        By logout = By.Id("logout_sidebar_link");

        public void openSidemenu()
        {
            driver.FindElement(sidemenu).Click();
        }
        public void clickOnLogout()
        {
            driver.FindElement(logout).Click();
        }


    }
}
