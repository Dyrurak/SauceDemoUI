using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemoUI.Service.WebDriverService
{
    public class WebDriverService
    {
        public IWebDriver webDriver;
        public IWebDriver SetWebDriverAsChrome(string driverPath)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("start-maximized");
            chromeOptions.AddArguments("test-type");
            chromeOptions.AddArguments("disable-popup-blocking");
            chromeOptions.AddArguments("ignore-certificate-errors");
            chromeOptions.AddArguments("disable-translate");
            chromeOptions.AddArguments("disable-automatic-password-saving");
            chromeOptions.AddArguments("allow-silent-push");
            chromeOptions.AddArguments("disable-infobars");
            chromeOptions.AddArguments("disable-notifications");
            chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
            webDriver = new ChromeDriver(driverPath, chromeOptions);
            return webDriver;
        }
    }
}
