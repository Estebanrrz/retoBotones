using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace retoBotones.POM
{
    public class TestsPage : BasePage
    {
        List<List<IWebElement>> buttonsMatrix;
        string split;
        public TestsPage(IWebDriver driver) : base(driver)
        {
        }
        #region locators
        private const string XPATH_COORDINATES = "//p[@class='text-center text-xl font-bold']";
        private const string XPATH_BUTTONS = "//button[@type='button']";
        private const string XPATH_BUTTON_SUBMIT = "//button[@type='submit']";
        private const string XPATH_INPUT_NUTTON = "//input[@type='number']";
        #endregion
        #region Methods
        public string TextCoordinates()
        {
            return Driver.FindElement(By.XPath(XPATH_COORDINATES)).Text;
        }
        public  bool DoesCoordinatesTextIsPresent()
        {
            return Driver.FindElements(By.XPath(XPATH_COORDINATES)).Count > 0;
        }
        public List<List<IWebElement>> GetButtons()
        {
            buttonsMatrix = new List<List<IWebElement>>();

            var buttons = Driver.FindElements(By.XPath(XPATH_BUTTONS)).ToList();
            int matrixSize = Convert.ToInt32(Math.Sqrt(buttons.Count));
            int init = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                List<IWebElement> row = new List<IWebElement>();
                row = buttons.GetRange(init, matrixSize);
                buttonsMatrix.Add(row);
                init = init + matrixSize;
            }



            return buttonsMatrix;
        }

        public void CalculateCoordinatesBoton(out int coordenadaXFinal, out int coordenadaYFinal)
        {
            string coordenadas = TextCoordinates();
            int indexOfsplit = coordenadas.IndexOf(")");
            split = coordenadas.Substring(indexOfsplit + 1, 1);
            if (split != ",")
            {
                coordenadas = coordenadas.Replace(split, ",");
            }
            string[] coordenadasSeparadas = coordenadas.Replace(")", "").Replace("(", "").Split(",");


            List<int> coordenadaX = new List<int>();
            List<int> coordenadaY = new List<int>();
            int cont = 0;
            foreach (string item in coordenadasSeparadas)
            {
                var number = int.Parse(item);
                if (cont % 2 == 0)
                {
                    coordenadaX.Add(number);
                }
                else
                {
                    coordenadaY.Add(number);
                }
                cont++;
            }

            coordenadaXFinal = coordenadaX.Sum(x => int.Parse(x.ToString()));
            coordenadaYFinal = coordenadaY.Sum(x => int.Parse(x.ToString()));



        }

        public void ClickSelectedButton()
        {
            WebDriverWait wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(10));

            var buttons = GetButtons();
            int coordenadaXFinal;
            int coordenadaYFinal;
            CalculateCoordinatesBoton(out coordenadaXFinal, out coordenadaYFinal);
            IWebElement boton = buttons[coordenadaYFinal][coordenadaXFinal];
            IJavaScriptExecutor js;
            js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", boton);
            wait.Until(ExpectedConditions.ElementToBeClickable(boton));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(XPATH_BUTTONS)));
            boton.Click();
            int sum = buttonsMatrix[coordenadaYFinal].Sum(x => int.Parse(x.Text));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(XPATH_INPUT_NUTTON)));
            Driver.FindElement(By.XPath(XPATH_INPUT_NUTTON)).SendKeys(sum.ToString());
            Driver.FindElement(By.XPath(XPATH_BUTTON_SUBMIT)).Click();

        }

        public void TypeSum()
        {



        }


        #endregion

    }
}
