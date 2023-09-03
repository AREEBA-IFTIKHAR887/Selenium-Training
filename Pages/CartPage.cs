
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumTraining.BaseClass;

namespace SeleniumTraining.Pages
{
    public class CartPage : BaseTest
    {
       
        By checkoutBtn = By.XPath("//button[@id='checkout']");
        By continueShoppingBtn = By.Id("continue-shopping");
        By removeBtnForBackPack = By.XPath("//div//button[@id='remove-sauce-labs-backpack']");
        By removeBtnForJacket = By.XPath("//div//button[@id='remove-sauce-labs-fleece-jacket']");
        public void clickCheckoutBtn()
        {

            driver.FindElement(checkoutBtn).Click();
        }
        public void clickContinueShoppingBtn()
        {
            driver.FindElement(continueShoppingBtn).Click();
        }
        public void removeItemFormCart(string itemName)
        {
            if (itemName=="Back Pack")
            {
                driver.FindElement(removeBtnForBackPack).Click();

            }
            else if(itemName=="Jacket")
            {
                driver.FindElement(removeBtnForJacket).Click();
            }

        }

    }
}
