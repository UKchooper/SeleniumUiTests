using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using SeleniumUiTests.Helpers;
using TechTalk.SpecFlow.Infrastructure;

namespace SeleniumUiTests.ApplicationModel
{
    class NavigationWindow
    {
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public NavigationWindow(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        private WindowsElement SettingsButton => ApplicationDriver.CalculatorSession.FindElementWait(MobileBy.AccessibilityId("SettingsItem"));

        public void ClickSettingsButton()
        {
            SettingsButton.ClickAndLog(nameof(SettingsButton), _specFlowOutputHelper);
        }
    }
}
