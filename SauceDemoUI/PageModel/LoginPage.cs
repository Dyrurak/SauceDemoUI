using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SauceDemoUI.PageModel
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {            
        }

        [FindsBy(How = How.Id, Using = "user-name")]
        public IWebElement txtUsername;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement txtPassword;

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement btnLogin;

        [FindsBy(How = How.XPath, Using = "//*[@data-test='error']")]
        public IWebElement lblIncorrectLoginError;
        


        public void SetUsername(string username)
        {
            SetText(txtUsername, username);
        }

        public void SetPassword(string password)
        {
            SetText(txtPassword, password);
        }

        public void ClickLoginButton()
        {
            Click(btnLogin);
        }

        public string GetLoginError()
        {            
            return lblIncorrectLoginError.Text;
        }

        public bool IsLoginButtonVisible()
        {
            return IsElementVisible("//*[@id='login-button']");
        }
    }
}