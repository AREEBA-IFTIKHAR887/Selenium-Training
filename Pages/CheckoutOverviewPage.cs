using OpenQA.Selenium;
using SeleniumTraining.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTraining.Pages
{
    public class CheckoutOverviewPage:BaseTest
    {
        By finishBtn = By.XPath("//div//button[@id='finish']");
        By cancelBtn = By.Id("cancel");
        public void clickfinishBtn()
        {
            driver.FindElement(finishBtn).Click();
        }
        public void clickcancelBtn()
        {
            driver.FindElement(cancelBtn).Click();
        }
    }
}
