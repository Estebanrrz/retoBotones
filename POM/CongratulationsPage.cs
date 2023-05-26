using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace retoBotones.POM
{
    public class CongratulationsPage : BasePage
    {
        public CongratulationsPage(IWebDriver driver) : base(driver)
        {
            
        }
        #region locators
        private const string XPATH_CONGRATULATIONS = "//h1[@class='text-center text-3xl p-5']";
        #endregion
        #region Methods
          public string TextCongratulations()
        {
            WebDriverWait wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(XPATH_CONGRATULATIONS)));
            return Driver.FindElement(By.XPath(XPATH_CONGRATULATIONS)).Text;
        }
        #endregion
    }
}
