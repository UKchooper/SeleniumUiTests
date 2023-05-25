using NUnit.Framework;
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

        private WindowsElement CalculatorWindowTitle => CalculatorWindow.FindElementWait(MobileBy.AccessibilityId("AppName"));
        private WindowsElement OpenNavigationButton => CalculatorWindow.FindElementWait(MobileBy.Name("Open Navigation"));

        public void LaunchSoftware()
        {
            ApplicationDriver.LaunchCalculator();
        }

        public void VerifyCalculatorMainWindow()
        {
            var expectedTitleName = "Calculator";

            Assert.AreEqual(expectedTitleName, CalculatorWindowTitle.Text);
            _specFlowOutputHelper.WriteLine($"{CalculatorWindowTitle.Text} is equals to {expectedTitleName}");
        }

        public void ClickOpenNavigationButton()
        {
            OpenNavigationButton.ClickAndLog(nameof(OpenNavigationButton), _specFlowOutputHelper);
        }
    }
}
