using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumTraining.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumTraining.BaseClass;

namespace SeleniumTraining.Tests
{
    [TestClass]
    public class CheckoutInformation : BaseTest
    {
        InventoryPage inventoryPage = new InventoryPage();
        CartPage cartPage = new CartPage();
        CheckoutInformationPage checkoutInfopage = new CheckoutInformationPage();
        CheckoutOverviewPage checkoutOverviewPage = new CheckoutOverviewPage();


        [TestMethod]
        public void mandatortyFieldFirstNameMissing()
        {
            List<string> itemList = new List<string>();
            itemList.Add("Back pack");
            itemList.Add("Jacket");
            for (int i = itemList.Count - 1; i >= 0; i--)
            {
                string item = itemList.ElementAt(i);
                inventoryPage.additemToCart(item);

            }
            inventoryPage.openCart();
            By qtyLabel = By.XPath("//div[@class='cart_quantity_label']");
            var element1 = driver.FindElements(qtyLabel).Count >= 1 ? driver.FindElement(qtyLabel) : null;
            Assert.IsNotNull(element1);
            By descLabel = By.XPath("//div[@class='cart_desc_label']");
            var element2 = driver.FindElements(descLabel).Count >= 1 ? driver.FindElement(descLabel) : null;
            Assert.IsNotNull(element2);
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            w.Until(ExpectedConditions.ElementToBeClickable(By.Id("checkout")));
            cartPage.clickCheckoutBtn();
            string checkoutPageHeading = driver.FindElement(By.XPath("//span[contains(@class, 'title') and text()='Checkout: Your Information']")).Text;
            Assert.AreEqual("Checkout: Your Information", checkoutPageHeading);
            checkoutInfopage.clickContinue();
            string validationMsg = driver.FindElement(By.XPath("//div[@class='error-message-container error']")).Text;
            Assert.AreEqual("Error: First Name is required", validationMsg);
        }
        [TestMethod]
        public void specialCharInNameFields()
        {
            List<string> itemList = new List<string>();
            itemList.Add("Back pack");
            itemList.Add("Jacket");
            for (int i = itemList.Count - 1; i >= 0; i--)
            {
                string item = itemList.ElementAt(i);
                inventoryPage.additemToCart(item);

            }
            inventoryPage.openCart();
            By qtyLabel = By.XPath("//div[@class='cart_quantity_label']");
            var element1 = driver.FindElements(qtyLabel).Count >= 1 ? driver.FindElement(qtyLabel) : null;
            Assert.IsNotNull(element1);
            By descLabel = By.XPath("//div[@class='cart_desc_label']");
            var element2 = driver.FindElements(descLabel).Count >= 1 ? driver.FindElement(descLabel) : null;
            Assert.IsNotNull(element2);
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            w.Until(ExpectedConditions.ElementToBeClickable(By.Id("checkout")));
            cartPage.clickCheckoutBtn();
            string checkoutPageHeading = driver.FindElement(By.XPath("//span[contains(@class, 'title') and text()='Checkout: Your Information']")).Text;
            Assert.AreEqual("Checkout: Your Information", checkoutPageHeading);
            checkoutInfopage.fillDetails("demo2");
            checkoutInfopage.clickContinue();
            string myurl = driver.Url;
            Assert.AreEqual("https://www.saucedemo.com/checkout-step-two.html", myurl);

        }

    }

}
