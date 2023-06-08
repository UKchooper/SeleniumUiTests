using SeleniumUiTests.ApplicationModel;
using TechTalk.SpecFlow;

namespace SeleniumUiTests.Steps
{
    [Binding]
    class MainWindowSteps
    {
        private readonly MainWindow _calculatorMainWindow;

        public MainWindowSteps(MainWindow calculatorMainWindow)
        {
            _calculatorMainWindow = calculatorMainWindow;
        }

        [Given(@"Calculator is launched")]
        public void GivenCalculatorIsLaunched()
        {
            _calculatorMainWindow.LaunchSoftware();
            _calculatorMainWindow.VerifyCalculatorMainWindow();
        }

        [When(@"Two numbers are added '([^']*)' and '([^']*)' together")]
        public void WhenTwoNumbersAreAddedAndTogether(int firstNum, int secondNum)
        {
            _calculatorMainWindow.AddNumbersTogether(firstNum, secondNum);
        }

        [When(@"Two numbers are subtracted (.*) and (.*)")]
        public void WhenTwoNumbersAreSubtractedAnd(int firstNum, int secondNum)
        {
            _calculatorMainWindow.MinusNumbersTogether(firstNum, secondNum);
        }

        [When(@"Two numbers are (.*) together (.*) and (.*)")]
        public void WhenTwoNumbersAreAnd(string operation, string firstNum, string secondNum)
        {
            _calculatorMainWindow.VarOperationNumbersTogether(operation, firstNum, secondNum);
        }

        [When(@"Verify the result '(.*)'")]
        public void WhenVerifyTheResult(string expectedResult)
        {
            _calculatorMainWindow.VerifyCalculatorResult(expectedResult);
        }

        [Then(@"Verify the result contains (.*)")]
        public void WhenVerifyTheResultContains(string expectedResult)
        {
            _calculatorMainWindow.VerifyCalculatorResult(expectedResult);
        }

        [When(@"History is navigated to")]
        public void WhenHistoryIsNavigatedTo()
        {
            _calculatorMainWindow.ClickHistoryButton();
        }

        [Then(@"Verify Calculator history is blank")]
        public void ThenVerifyCalculatorHistoryIsBlank()
        {
            _calculatorMainWindow.VerifyHistoryIsEmpty();
        }

        [Then(@"Verify default memory buttons")]
        public void ThenVerifyDefaultMemoryButtons()
        {
            _calculatorMainWindow.VerifyDefaultMemoryButtons();
        }

        [When(@"Get page source data")]
        public void WhenGetPageSourceData()
        {
            _calculatorMainWindow.GetDriverPageSource();
        }
    }
}
