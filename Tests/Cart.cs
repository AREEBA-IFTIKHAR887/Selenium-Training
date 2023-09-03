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
    public class Cart:BaseTest
    {
        InventoryPage inventoryPage = new InventoryPage();
        CartPage cartPage = new CartPage();
        CheckoutInformationPage checkoutInfopage = new CheckoutInformationPage();
        CheckoutOverviewPage checkoutOverviewPage = new CheckoutOverviewPage();

        [TestMethod]
        public void verifyContinueShopping()
        {
            Dictionary<string, double> itemList = new Dictionary<string, double>();
            itemList.Add("Back pack", 29.99);
            itemList.Add("Bike light", 9.99);
            itemList.Add("Jacket", 49.99);
            for (int i = itemList.Count - 1; i >= 0; i--)
            {
                string item = itemList.ElementAt(i).Key;
                inventoryPage.additemToCart(item);
                Console.WriteLine(item);
            }
            inventoryPage.openCart();
            By qtyLabel = By.XPath("//div[@class='cart_quantity_label']");
            var element1 = driver.FindElements(qtyLabel).Count >= 1 ? driver.FindElement(qtyLabel) : null;
            Assert.IsNotNull(element1);
            By descLabel = By.XPath("//div[@class='cart_desc_label']");
            var element2 = driver.FindElements(descLabel).Count >= 1 ? driver.FindElement(descLabel) : null;
            Assert.IsNotNull(element2);
            cartPage.clickContinueShoppingBtn();
            string myurl = driver.Url;
            Assert.AreEqual("https://www.saucedemo.com/inventory.html", myurl);


        }
        [TestMethod]
        public void checkoutEmptyCart()
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
            cartPage.removeItemFormCart("Back Pack");
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            w.Until(ExpectedConditions.ElementToBeClickable(By.Id("checkout")));
            cartPage.clickCheckoutBtn();
            string myurl = driver.Url;
            Assert.AreEqual("https://www.saucedemo.com/checkout-step-one.html", myurl);

        



        }
    }
}
