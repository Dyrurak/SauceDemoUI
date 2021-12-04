using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace SauceDemoUI.PageModel
{
    public class CartPage : BasePage
    {
        
        public CartPage(IWebDriver webDriver) : base(webDriver)
        {            
        }
                
        [FindsBy(How = How.XPath, Using = "//*[@class='inventory_item_name']")]
        public IList<IWebElement> lblListProductNameInCart;

        [FindsBy(How = How.XPath, Using = "//*[@class='btn btn_secondary btn_small cart_button']")]
        public IList<IWebElement> btnListRemoveProductFromCart;

        [FindsBy(How = How.Id, Using = "checkout")]
        public IWebElement btnCheckout;

        [FindsBy(How = How.Id, Using = "first-name")]
        public IWebElement txtFirstName;

        [FindsBy(How = How.Id, Using = "last-name")]
        public IWebElement txtLastName;

        [FindsBy(How = How.Id, Using = "postal-code")]
        public IWebElement txtPostalCode;

        [FindsBy(How = How.Id, Using = "continue")]
        public IWebElement btnContinue;        

        [FindsBy(How = How.Id, Using = "finish")]
        public IWebElement btnFinish;

        [FindsBy(How = How.XPath, Using = "//*[@class='complete-text']")]
        public IWebElement lblOrderConfirmation;
        
        public int GetQuantityOfProductsInCart()
        {
            return lblListProductNameInCart.Count;
        }

        public void ClickRemoveButtonForAllProductsInCart()
        {
            foreach (IWebElement btnRemove in btnListRemoveProductFromCart)
            {
                Click(btnRemove);
            }
        }

        public void ClickCheckoutButton()
        {
            Click(btnCheckout);
        }

        public void SetFirstName(string firstName)
        {
            SetText(txtFirstName, firstName);
        }

        public void SetLastName(string lastName)
        {
            SetText(txtLastName, lastName);
        }

        public void SetPostalCode(string postalCode)
        {
            SetText(txtPostalCode, postalCode);
        }

        public void ClickContinueButton()
        {
            Click(btnContinue);
        }

        public void ClickFinishButton()
        {
            Click(btnFinish);
        }

        public string GetOrderConfirmationText()
        {
            return lblOrderConfirmation.Text;
        }
    }
}