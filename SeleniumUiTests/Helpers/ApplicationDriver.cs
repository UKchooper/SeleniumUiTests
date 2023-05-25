using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace SeleniumUiTests.Helpers
{
    public static class ApplicationDriver
    {
        private const string AppProcessName = "Calc";
        private const string NativeWindowHandle = "NativeWindowHandle";
        private const string CalculatorMainWindow = "Calculator";
        private const string AppTopLevelWindow = "appTopLevelWindow";
        private static readonly Uri DriverUri = new Uri(Extensions.WindowsApplicationDriverUrl);

        public static WindowsDriver<WindowsElement> DesktopSession;
        public static WindowsDriver<WindowsElement> CalculatorSession;
        public static string CalcTopLevelWindowHandle;

        public static void LaunchCalculator()
        {
            CommonHelpers.LaunchApplication(AppProcessName);

            var desktopOptions = new AppiumOptions();
            desktopOptions.AddAdditionalCapability("app", "Root");

            DesktopSession = new WindowsDriver<WindowsElement>(DriverUri, desktopOptions, TimeSpan.FromSeconds(20));

            var calculatorWindow = DesktopSession.FindElementWait(MobileBy.Name(CalculatorMainWindow), 60);
            CalcTopLevelWindowHandle = calculatorWindow.GetAttribute(NativeWindowHandle);
            CalcTopLevelWindowHandle = int.Parse(CalcTopLevelWindowHandle).ToString("x");

            var appCapabilities = new AppiumOptions();
            appCapabilities.AddAdditionalCapability(AppTopLevelWindow, CalcTopLevelWindowHandle);
            CalculatorSession = new WindowsDriver<WindowsElement>(DriverUri, appCapabilities);
        }
    }
}
