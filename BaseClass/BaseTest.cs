using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTraining.BaseClass
{
    public class BaseTest
    {
        public static IWebDriver driver;
        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}
