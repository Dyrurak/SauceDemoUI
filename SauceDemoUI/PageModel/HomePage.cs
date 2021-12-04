using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace SauceDemoUI.PageModel
{
    public class HomePage : BasePage
    {
        public ProductPage productPage;

        public HomePage(IWebDriver webDriver) : base(webDriver)
        {
            productPage = new ProductPage(webDriver);
        }

        [FindsBy(How = How.Id, Using = "react-burger-menu-btn")]
        public IWebElement btnMenu;

        [FindsBy(How = How.Id, Using = "inventory_sidebar_link")]
        public IWebElement btnAllItems;        

        [FindsBy(How = How.Id, Using = "shopping_cart_container")]
        public IWebElement btnShoppingCart;

        [FindsBy(How = How.Id, Using = "logout_sidebar_link")]
        public IWebElement btnLogout;

        [FindsBy(How = How.Id, Using = "about_sidebar_link")]
        public IWebElement btnAbout;

        [FindsBy(How = How.XPath, Using = "//*[@class='btn btn_primary btn_small btn_inventory']")]
        public IList<IWebElement> btnListAddToChart;

        [FindsBy(How = How.XPath, Using = "//*[@class='inventory_item_name']")]
        public IList<IWebElement> lblListProductItemNames;

        [FindsBy(How = How.XPath, Using = "(//*[@class='inventory_item_name'])[1]")]
        public IWebElement lblFirstProduct;

        public bool IsMenuButtonVisible()
        {
            return IsElementVisible("//*[@id='react-burger-menu-btn']");
        }

        public void ClickMenuButton()
        {
            Click(btnMenu);
        }
        
        public void ClickLogoutButton()
        {
            Click(btnLogout);
        }

        public void ClickAboutButton()
        {
            Click(btnAbout);
        }

        public void ClickAddToChartOfAllProducts()
        {
            foreach (IWebElement addToCart in btnListAddToChart)
            {
                Click(addToCart);
            }
        }

        public int GetAllProductsQuantity()
        {
            return btnListAddToChart.Count;
        }

        public List<string> GetProductListInHomePage()
        {
            List<string> productsList = new List<string>();
            foreach (IWebElement product in lblListProductItemNames)
            {
                productsList.Add(product.Text);
            }
            return productsList;
        }

        public void ClickShoppingCart()
        {
            Click(btnShoppingCart);
        }

        public void ClickAllItemsButton()
        {
            Click(btnAllItems);
        }

        public void ClickFirstProductName()
        {
            Click(lblFirstProduct);
        }
    }
}