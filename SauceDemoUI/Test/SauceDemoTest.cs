using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoUI.PageModel;
using SauceDemoUI.Service.WebDriverService;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SauceDemoUI.Test
{
    [Binding, Scope(Feature= "SauceDemoLoginPage"), Scope(Feature= "SauceDemoHomePage"), Scope(Feature="SauceDemoCartPage"), Scope(Feature= "SauceDemoProductPage")]   
    public class SauceDemoTest
    {
        public IWebDriver webDriver;
        private readonly string driverPath = string.Empty;
        public WebDriverService webDriverService;
        public LoginPage loginPage;
        public HomePage homePage;
        public CartPage cartPage;
        public ProductPage productPage;
        public int quantityOfAllProducts = 0;

        public SauceDemoTest()
        {
            driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            webDriverService = new WebDriverService();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            webDriver.Quit();
        }

        [StepDefinition(@"Chrome Browser is opened")]
        public void OpenBrowser()
        {           
            webDriver = webDriverService.SetWebDriverAsChrome(driverPath);               
            loginPage = new LoginPage(webDriver);
            homePage = new HomePage(webDriver);
            cartPage = new CartPage(webDriver);
            productPage = new ProductPage(webDriver);
        }

        [StepDefinition(@"'(.*)' page is opened")]
        public void OpenWebSiteUrl(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        [StepDefinition(@"'(.*)' is entered as username")]
        public void SetUsername(string username)
        {
            loginPage.SetUsername(username);
        }

        [StepDefinition(@"'(.*)' is entered as password")]
        public void SetPassword(string password)
        {
            loginPage.SetPassword(password);
        }

        [StepDefinition(@"Login button is clicked")]
        public void ClickLoginButton()
        {
            loginPage.ClickLoginButton();
        }

        [StepDefinition(@"Login operation is performed successfully")]
        public void CheckLoginOperationIsSuccessful()
        {
            Assert.IsTrue(homePage.IsMenuButtonVisible(), "Login failed!");
        }

        [StepDefinition(@"'(.*)' error is seen")]
        public void CheckLoginOperationIsInCorrect(string expectedError)
        {            
            Assert.AreEqual(expectedError, loginPage.GetLoginError(), expectedError + " error was not seen!");
        }

        [StepDefinition(@"Menu button is clicked")]
        public void ClickMenuButton()
        {
            homePage.ClickMenuButton();
        }

        [StepDefinition(@"Logout button is clicked")]
        public void ClickLogoutButton()
        {
            homePage.ClickLogoutButton();
        }

        [StepDefinition(@"Logout operation is performed successfully")]
        public void CheckLogoutOperationIsSuccessful()
        {
            Assert.IsTrue(loginPage.IsLoginButtonVisible(), "Logout failed!");
        }

        [StepDefinition(@"About button is clicked")]
        public void ClickAboutButton()
        {
            homePage.ClickAboutButton();
        }

        [StepDefinition(@"All items button is clicked")]
        public void ClickAllItemsButton()
        {
            homePage.ClickAllItemsButton();
        }


        [StepDefinition(@"'(.*)' url is seen")]
        public void CheckUrlIsCorrect(string expectedUrl)
        {
            Assert.AreEqual(expectedUrl, homePage.GetUrlOfCurrentPage(), expectedUrl + " url was not opened! ");
        }

        [StepDefinition(@"All the products are seen in home page")]
        public void CheckNamesOfAllProducts()
        {
            Assert.IsNotNull(homePage.GetProductListInHomePage(), "Products could not be loaded in the page!");
        }

        [StepDefinition(@"All products are added to cart")]
        public void AddAllProductsToCart()
        {
            quantityOfAllProducts = homePage.GetAllProductsQuantity();
            homePage.ClickAddToChartOfAllProducts();
        }

        [StepDefinition(@"Cart button is clicked")]
        public void ClickShoppingCart()
        {
            homePage.ClickShoppingCart();
        }

        [StepDefinition(@"Quantity of products is checked in cart")]
        public void CheckQuantityOfProductsInCart()
        {
            Assert.AreEqual(quantityOfAllProducts, cartPage.GetQuantityOfProductsInCart(), "All added products were not added to cart! ");
        }

        [StepDefinition(@"All products are removed in cart successfully")]
        public void RemoveAllProductsInCart()
        {
            cartPage.ClickRemoveButtonForAllProductsInCart();
        }

        [StepDefinition(@"Checkout button is clicked")]
        public void ClickCheckoutButton()
        {
            cartPage.ClickCheckoutButton();
        }

        [StepDefinition(@"'(.*)' is written as First Name")]
        public void SetFirstName(string firstName)
        {
            cartPage.SetFirstName(firstName);
        }

        [StepDefinition(@"'(.*)' is written as Last Name")]
        public void SetLastName(string lastName)
        {
            cartPage.SetLastName(lastName);
        }

        [StepDefinition(@"'(.*)' is written as Zip/Postal Code")]
        public void SetZipPostalCode(string zipPostalCode)
        {
            cartPage.SetPostalCode(zipPostalCode);
        }

        [StepDefinition(@"Continue button is clicked")]
        public void ClickContinueButton()
        {
            cartPage.ClickContinueButton();
        }

        [StepDefinition(@"Finish button is clicked")]
        public void ClickFinishButton()
        {
            cartPage.ClickFinishButton();
        }

        [StepDefinition(@"'(.*)' message is seen")]
        public void CheckPurchaseOperationIsCompletedSuccessfully(string expectedMessage)
        {
            Assert.AreEqual(expectedMessage, cartPage.GetOrderConfirmationText(), "Purchase operation failed! ");
        }

        [StepDefinition(@"First product is clicked")]
        public void ClickFirstProduct()
        {
            homePage.ClickFirstProductName();
        }

        [StepDefinition(@"Add to cart button is clicked")]
        public void ClickAddToCart()
        {
            productPage.ClickAddToCart();
        }

        [StepDefinition(@"Remove button is seen")]
        public void CheckRemoveButtonIsVisible()
        {
            Assert.IsTrue(productPage.IsRemoveButtonVisible(),"Product could not be added to cart! ");
        }
    }
}