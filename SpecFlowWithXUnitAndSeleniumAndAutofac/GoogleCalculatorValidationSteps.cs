using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowWithXUnitAndSeleniumAndAutofac {
    [Binding]
    public class GoogleCalculatorValidationSteps {
        private const string GOOGLE_CALC_URL = "https://www.google.com/search?q=";
        private const string GOOGLE_CALC_RESULT_ID_TAG = "cwos";
        private readonly ICalculator calculator;

        public GoogleCalculatorValidationSteps(ICalculator calculator) {
            this.calculator = calculator;
        }

        [Then(@"the result should be same as in google calc")]
        public void ThenTheResultShouldBeSameAsInGoogleCalc() {
            using (IWebDriver webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))) {
                webDriver.Navigate().GoToUrl($"{GOOGLE_CALC_URL}{Uri.EscapeDataString(calculator.LastOperationAsQuery)}");
                int resultByGoogle = Convert.ToInt32(webDriver.FindElement(By.Id(GOOGLE_CALC_RESULT_ID_TAG)).Text);
                Assert.Equal(resultByGoogle, calculator.Result);
                
            }
        }
    }
}