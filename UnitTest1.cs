using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using retoBotones.POM;

namespace retoBotones
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://tasks.evalartapp.com/automatization/");
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver?.Quit();
        }


        [TestMethod]
        public void TestMethod1()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("612598", "10df2f32286b7120My0zLTg5NTIxNg==30e0c83e6c29f1c3");
            TestsPage testsPage = new TestsPage(driver);
            while (testsPage.DoesCoordinatesTextIsPresent())
            {

                testsPage.ClickSelectedButton();

            }
            CongratulationsPage congratulationsPage = new CongratulationsPage(driver);

            Assert.IsTrue(congratulationsPage.TextCongratulations().Contains("Congratulations"));

        }
    }
}