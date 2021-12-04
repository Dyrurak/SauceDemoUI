using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;


namespace SauceDemoUI.PageModel
{
    public class BasePage
    {
        private IWebDriver webDriver;
        public BasePage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(webDriver, this);
        }

        public IWebElement Find(By by)
        {
            return webDriver.FindElement(by);
        }

        public void Click(IWebElement btn)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(btn));
            btn.Click();
        }

        public void SetText(IWebElement txt, string text)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(txt));
            txt.SendKeys(text);
        }

        public IJavaScriptExecutor GetScriptExecutor()
        {
            return (IJavaScriptExecutor)webDriver;
        }

        public void DismissModalAlert()
        {
            IAlert alert = webDriver.SwitchTo().Alert();
            alert.Dismiss();
        }

        public bool IsElementVisible(string webElement)
        {
            bool isElementSeen;
            try
            {
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(webElement)));
                isElementSeen = true;
            }
            catch (Exception)
            {
                isElementSeen = false;
            }
            return isElementSeen;
        }

        public void InitElements(object elementLocator)
        {
            PageFactory.InitElements(webDriver, elementLocator);
        }

        public void CloseBrowser()
        {
            webDriver.Quit();
        }

        public void WaitStatically(int second)
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(second);
        }

        public ReadOnlyCollection<string> GetWindowHandles()
        {
            try
            {
                return webDriver.WindowHandles;
            }
            catch
            {
                throw new Exception("Window could not be found! ");
            }
        }

        public void SwitchToWindow(string windowName)
        {
            try
            {
                webDriver.SwitchTo().Window(windowName);
            }
            catch
            {
                throw new Exception("Could not be switchted to requested window! ");
            }
        }

        public void SwictToFirstWindow()
        {
            try
            {
                webDriver.SwitchTo().Window(webDriver.WindowHandles.FirstOrDefault());
            }
            catch
            {
                throw new Exception("Could not be switched to first window! ");
            }
        }

        public void SwitchToLastWindow()
        {
            try
            {
                webDriver.SwitchTo().Window(webDriver.WindowHandles.Last());
            }
            catch
            {
                throw new Exception("Could not be switched to last window! ");
            }
        }

        public string GetAlertText()
        {
            try
            {
                return webDriver.SwitchTo().Alert().Text;
            }
            catch
            {
                throw new Exception("No alert occured! ");
            }
        }

        public string GetTextOfElement(IWebElement webElement)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement));
                return webElement.Text;
            }
            catch
            {
                throw new Exception("Text of web element could not be found! ");
            }
        }
        
        public string GetUrlOfCurrentPage()
        {
            return webDriver.Url;
        }

        public void RefreshPage()
        {
            webDriver.Navigate().Refresh();
        }
    }
}