using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace retoBotones.POM
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        #region Locators
        private const string XPATH_USERNAME = "//input[@name='username']";
        private const string XPATH_PASSWORD = "//input[@name='password']";
        private const string XPATH_SENT_BUTTON = "//button[@type='submit']";
        #endregion
        #region Methods
        public void Login(string username, string password)
        {
            Driver.FindElement(By.XPath(XPATH_USERNAME)).SendKeys(username);
            Driver.FindElement(By.XPath(XPATH_PASSWORD)).SendKeys(password);
            Driver.FindElement(By.XPath(XPATH_SENT_BUTTON)).Click();
        }

        #endregion



    }
}
