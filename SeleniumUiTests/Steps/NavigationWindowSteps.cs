using SeleniumUiTests.ApplicationModel;
using TechTalk.SpecFlow;

namespace SeleniumUiTests.Steps
{
    [Binding]
    class NavigationWindowSteps
    {
        private readonly MainWindow _calculatorMainWindow;
        private readonly NavigationWindow _navigationWindow;

        public NavigationWindowSteps(MainWindow calculatorMainWindow, NavigationWindow navigationWindow)
        {
            _calculatorMainWindow = calculatorMainWindow;
            _navigationWindow = navigationWindow;
        }

        [When(@"Setting is navigated to")]
        public void WhenSettingIsNavigatedTo()
        {
            _calculatorMainWindow.ClickOpenNavigationButton();
            _navigationWindow.ClickSettingsButton();
        }
    }
}
