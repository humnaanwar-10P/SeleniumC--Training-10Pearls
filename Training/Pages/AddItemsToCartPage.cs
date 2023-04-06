using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Pages
{
    public class AddItemsToCartPage:BaseClass
    {
        By btn1 = By.Id("add-to-cart-sauce-labs-backpack");
        By cart = By.XPath("/html/body/div/div/div/div[1]/div[1]/div[3]/a");
      //  By productName = By.XPath("/html/body/div/div/div/div[2]/div/div[1]/div[3]/div[2]/a");

        By continueShop = By.Id("continue-shopping");

        By btn2 = By.Id("add-to-cart-sauce-labs-bike-light");
        By btn3 = By.Id("add-to-cart-sauce-labs-bolt-t-shirt");
        By removeLights = By.Id("remove-sauce-labs-bike-light");
        By removeBackpack = By.Id("remove-sauce-labs-backpack");
        By removeTshirt = By.Id("remove-sauce-labs-bolt-t-shirt");

        public void AddBackPackToCart()
        {
            driver.FindElement(btn1).Click();
        }

        public void clickCart()
        {
            driver.FindElement(cart).Click();
        }

        public void clickContinueShopping()
        {
            driver.FindElement(continueShop).Click();
        }
        public void AddLightsToCart()
        {
            driver.FindElement(btn2).Click();
        }
        public void AddShirtToCart()
        {
            driver.FindElement(btn3).Click();
        }
        public void RemoveLightsFromCart()
        {
            driver.FindElement(removeLights).Click();
        }
        public void RemoveBackpackFromCart()
        {
            driver.FindElement(removeBackpack).Click();
        }
        public void RemoveTshirtFromCart()
        {
            driver.FindElement(removeTshirt).Click();
        }
    }

}
