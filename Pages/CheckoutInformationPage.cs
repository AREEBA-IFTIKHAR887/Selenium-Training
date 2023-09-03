using DotLiquid.Util;
using NPOI.XSSF.UserModel;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumTraining.BaseClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTraining.Pages
{
    
    public class CheckoutInformationPage : BaseTest
    {


        By FirstName = By.Id("first-name");
        By LastName=By.Id("last-name");
        By  ZipCode =By.Id("postal-code");
        By  continueBtn=By.Id("continue");        
        public void fillDetails(string excelfileName)
        {
            
            string path = @"D:\"+ excelfileName+ ".xlsx";
            XSSFWorkbook workbook = new XSSFWorkbook(File.Open(path, FileMode.Open));
            var sheet = workbook.GetSheetAt(1);
            var row = sheet.GetRow(1);
            var firstName = row.GetCell(0).StringCellValue;
            var lastName = row.GetCell(1).StringCellValue;
            var zipCode = row.GetCell(2).NumericCellValue;          
            driver.FindElement(FirstName).SendKeys(firstName); 
            driver.FindElement(LastName).SendKeys(lastName);
            driver.FindElement(ZipCode).SendKeys(zipCode.ToString());

        }

        public void clickContinue()
        {
            driver.FindElement(continueBtn).Click();
        }
        
    }
}
