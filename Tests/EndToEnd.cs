using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.XSSF.UserModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTraining.BaseClass;
using SeleniumTraining.Pages;

namespace SeleniumTraining.Tests
{
    [TestClass]
    public class EndToEnd : BaseTest
    {
        InventoryPage inventoryPage = new InventoryPage();
        CartPage cartPage = new CartPage();
        CheckoutInformationPage checkoutInfopage = new CheckoutInformationPage();
        CheckoutOverviewPage checkoutOverviewPage = new CheckoutOverviewPage();
        CheckoutCompletePage checkoutCompletePage = new CheckoutCompletePage();
        
        
        [TestMethod]
        public void EndToEndCase()
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
            cartPage.clickCheckoutBtn();
            string checkoutPageHeading = driver.FindElement(By.XPath("//span[contains(@class, 'title') and text()='Checkout: Your Information']")).Text;
            Assert.AreEqual("Checkout: Your Information",checkoutPageHeading );            
            checkoutInfopage.fillDetails("demo");
            checkoutInfopage.clickContinue();
            string total=driver.FindElement(By.XPath("//div[contains(@class, 'summary_subtotal_label') ]")).Text;                       
            string amount = total.Substring(total.LastIndexOf('$') + 1);
            double finaltotal=double.Parse(amount);
            double j = 0.00;
            for (int i = itemList.Count - 1; i >= 0; i--)
            {
                j = j+itemList.ElementAt(i).Value;                
            }
            Assert.AreEqual(j, finaltotal);
            checkoutOverviewPage.clickfinishBtn();
            IWebElement confirmationSign = driver.FindElement(By.XPath("//img[@class='pony_express']"));
            Assert.IsTrue(confirmationSign.Displayed);
            checkoutCompletePage.clickHamBurgerMenu();
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            w.Until(ExpectedConditions.ElementToBeClickable(By.Id("logout_sidebar_link")));
            checkoutCompletePage.clickLogout();
            string myurl = driver.Url;
            Assert.AreEqual("https://www.saucedemo.com/", myurl);


        }
    }
}
