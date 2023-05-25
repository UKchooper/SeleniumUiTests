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
    }
}
