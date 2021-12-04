using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SauceDemoUI.PageModel
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver webDriver) : base(webDriver)
        {            
        }

        [FindsBy(How = How.XPath, Using = "//*[@class='inventory_details_name large_size']")]
        public IWebElement lblProductName;

        [FindsBy(How = How.Id, Using = "back-to-products")]
        public IWebElement btnBackToProducts;

        [FindsBy(How = How.XPath, Using = "//*[@class='btn btn_primary btn_small btn_inventory']")]
        public IWebElement btnAddToCart;

             
        public string GetNameOfProduct()
        {
            return lblProductName.Text;
        }

        public void ClickBackToProductsButton()
        {
            Click(btnBackToProducts);
        }

        public void ClickAddToCart()
        {
            Click(btnAddToCart);
        }

        public bool IsRemoveButtonVisible()
        {
            return IsElementVisible("//*[@class='btn btn_secondary btn_small btn_inventory']");
        }
    }
}