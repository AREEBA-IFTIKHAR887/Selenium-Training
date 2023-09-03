using OpenQA.Selenium;
using SeleniumTraining.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeleniumTraining.Pages
{
    public class InventoryPage : BaseTest

    {
        By cartIcon = By.Id("shopping_cart_container");
        By addToCartBtnforBackPack = By.Name("add-to-cart-sauce-labs-backpack");
        By addToCartBtnforBikelight = By.Name("add-to-cart-sauce-labs-bike-light");
        By addToCartBtnforJacket = By.Name("add-to-cart-sauce-labs-fleece-jacket");

        public void addToCartBagPack()
        {
            driver.FindElement(addToCartBtnforBackPack).Click();

        }

        public void additemToCart(string itemName)
        {

            switch (itemName)
            {
                case "Back pack":

                    driver.FindElement(addToCartBtnforBackPack).Click();

                    break;
                case "Bike light":

                    driver.FindElement(addToCartBtnforBikelight).Click();

                    break;
                case "Jacket":

                    driver.FindElement(addToCartBtnforJacket).Click();

                    break;
                
            }


        }

        public void openCart()
        {
            driver.FindElement(cartIcon).Click();
        }

    }
}
