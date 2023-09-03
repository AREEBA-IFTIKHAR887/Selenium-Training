using OpenQA.Selenium;
using SeleniumTraining.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTraining.Pages
{
    public class CheckoutCompletePage:BaseTest
    {
        By hamburgerMenu = By.XPath("//button[@id='react-burger-menu-btn']");
        By logout = By.Id("logout_sidebar_link");
        public void clickHamBurgerMenu()
        {
            driver.FindElement(hamburgerMenu).Click();
        }
        public void clickLogout()
        {
            driver.FindElement(logout).Click();
        }
    }
}
