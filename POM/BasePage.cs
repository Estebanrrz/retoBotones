using OpenQA.Selenium;

namespace retoBotones.POM
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

    }
}
