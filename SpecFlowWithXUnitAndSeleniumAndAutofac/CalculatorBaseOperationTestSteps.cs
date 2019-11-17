using TechTalk.SpecFlow;

namespace SpecFlowWithXUnitAndSeleniumAndAutofac {
    [Binding]
    public class CalculatorBaseOperationTestSteps {
        private readonly ICalculator calculator;

        public CalculatorBaseOperationTestSteps(ICalculator calculator) {
            this.calculator = calculator;
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int operand) {
            calculator.Enter(operand);
        }

        [When(@"I press add")]
        public void WhenIPressAdd() {
            calculator.Add();
        }
    }
}