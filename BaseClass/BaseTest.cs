using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using excel = Microsoft.Office.Interop.Excel;
using NPOI.XSSF.UserModel;
using NPOI.SS.Formula.Functions;

namespace SeleniumTraining.BaseClass
{
    public class BaseTest
    {
        public static IWebDriver driver;

        [TestInitialize]
        public void setUp()
        {
            //excel.Application x1app = new excel.Application();
            //excel.Workbook x1workbook= x1app.Workbooks.Open(@"D:\Demo.xlsx");
            //excel._Worksheet x1sheet = x1workbook.Sheets[1];
            string path = @"D:\Demo.xlsx";
            XSSFWorkbook workbook = new XSSFWorkbook(File.Open(path, FileMode.Open));
            var sheet = workbook.GetSheetAt(0);
            var row = sheet.GetRow(0);
            var value=row.GetCell(0).StringCellValue.Trim();
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.FindElement(By.XPath("(//input[@class='input_error form_input'])[1]")).SendKeys(value);
            IWebElement password = driver.FindElement(By.XPath("//input[@id='password']"));
            password.SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();
            string actualTitle = driver.Title;
            Assert.AreEqual("Swag Labs", actualTitle);
        }

        [TestCleanup]

        public void tearDown()
        {
            driver.Quit();
        }
    }
}
