using DotLiquid.Tags;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml.Serialization;
using SeleniumTraining.BaseClass;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NuGet.Frameworks;

namespace SeleniumTraining
{
      [TestClass]   
        public class Login : BaseTest
        {
        
         public static IWebElement password;
        


        [DataTestMethod]
        [DataRow("https://www.saucedemo.com/", "standard_user")]
        [DataRow("https://www.saucedemo.com/", "performance_glitch_user")]
        public void loginpositivecase(string url, string userName)
        {

            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.XPath("(//input[@class='input_error form_input'])[1]")).SendKeys(userName);
            password= driver.FindElement(By.XPath("//input[@id='password']"));
            password.SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            w.Until(ExpectedConditions.ElementIsVisible(By.Id("shopping_cart_container")));
            string myurl = driver.Url;
            Assert.AreEqual("https://www.saucedemo.com/inventory.html", myurl);
            string actualTitle = driver.Title;
            Assert.AreEqual("Swag Labs", actualTitle);
            Console.WriteLine("Hello! Welcome to" + " "+ url + " "+ "You have logged in with username"+ " " + userName);
        }

        [TestMethod]
        public void loginnegativecase1()
        {

            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.FindElement(By.XPath("(//input[@class='input_error form_input'])[1]")).SendKeys("locked_out_user");
            password = driver.FindElement(By.XPath("//input[@id='password']"));
            password.SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();
            string actualError=driver.FindElement(By.XPath("*//div[@class='error-message-container error']")).Text;
            Assert.AreEqual("Epic sadface: Sorry, this user has been locked out.", actualError);
            string actualTitle = driver.Title;
            Assert.AreEqual("Swag Labs", actualTitle);

        }
        [TestMethod]
        public void loginnegativecase2()
        {

            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.FindElement(By.XPath("(//input[@class='input_error form_input'])[1]")).SendKeys("standard_user");
            password = driver.FindElement(By.XPath("//input[@id='password']"));
            password.SendKeys("invalidpassword");
            driver.FindElement(By.Id("login-button")).Click();
            string actualError = driver.FindElement(By.XPath("*//div[@class='error-message-container error']")).Text;
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", actualError);
            string actualTitle = driver.Title;
            Assert.AreEqual("Swag Labs", actualTitle);
        }

        [TestMethod]
        [Ignore]
        public void loginnegativecase3()
        {

            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.FindElement(By.XPath("(//input[@class='input_error form_input'])[1]")).SendKeys("invalid");
            password = driver.FindElement(By.XPath("//input[@id='password']"));
            password.SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();
            string actualError = driver.FindElement(By.XPath("*//div[@class='error-message-container error']")).Text;
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", actualError);
            string actualTitle = driver.Title;
            Assert.AreEqual("Swag Labs", actualTitle);

        }




    }
}