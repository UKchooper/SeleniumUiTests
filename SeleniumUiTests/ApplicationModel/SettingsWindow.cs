using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using SeleniumUiTests.Helpers;
using TechTalk.SpecFlow.Infrastructure;

namespace SeleniumUiTests.ApplicationModel
{
    class SettingsWindow
    {
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public SettingsWindow(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        private WindowsElement VersionText => ApplicationDriver.CalculatorSession.FindElementWait(MobileBy.AccessibilityId("AboutContentBody"));

        public void VerifyApplicationVersionText()
        {
            var trimmedVersionText = VersionText.Text.Remove(22);

            Assert.AreEqual("Calculator 11.2210.0.0", trimmedVersionText);
        }
    }
}
