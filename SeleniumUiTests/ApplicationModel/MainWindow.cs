using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using SeleniumUiTests.Helpers;
using TechTalk.SpecFlow.Infrastructure;

namespace SeleniumUiTests.ApplicationModel
{
    public class MainWindow
    {
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public MainWindow(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        private WindowsElement _calculatorWindow;

        private WindowsElement CalculatorWindow => _calculatorWindow ??=
            ApplicationDriver.CalculatorSession.FindElementWait(MobileBy.Name("Calculator"));

        public void LaunchSoftware()
        {
            ApplicationDriver.LaunchCalculator();
        }
    }
}
