using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTraining
{
    [TestClass]
    public class Session1
    {
        IWebDriver driver;

        [TestMethod]
        public void Task1()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://10pearlsuniversity.org/");
            string mytitle = driver.Title;
            VerifyTitle(mytitle);
            driver.Navigate().GoToUrl("https://www.facebook.com");
            driver.Navigate().GoToUrl("https://10pearlsuniversity.org/");
            string myUrl = driver.Url;
            Console.WriteLine(myUrl);
            driver.Navigate().Refresh();
            driver.Quit();
        }
        public static void VerifyTitle(string Titletext)

        {
            if (Titletext == "Home - 10PEARLS University")
            {
                Console.WriteLine("test passed");

            }
            else
            {
                Console.WriteLine("test failed");
                Assert.Fail();
            }
        }
        [TestMethod]
        public void Task2()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
            string myUrl = driver.Url;
            if (myUrl == "https://practicetestautomation.com/practice-test-login/")
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Assert.Fail();
            }
            driver.FindElement(By.Id("username")).SendKeys("student");
            driver.FindElement(By.Id("password")).SendKeys("Password123");
            driver.FindElement(By.Id("submit")).Click();
            string mytitle = driver.Title;
            Assert.AreEqual("Logged In Successfully | Practice Test Automation", mytitle);
            driver.Quit();



        }
    }
}