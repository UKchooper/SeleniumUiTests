using SeleniumUiTests.Helpers;
using TechTalk.SpecFlow;

namespace SeleniumUiTests.Hooks
{
    [Binding]
    class ApplicationHooks
    {
        [BeforeTestRun]
        static void SetupTests()
        {
            WinAppDriverHelper.LaunchWinAppDriver();
        }

        [AfterScenario]
        static void TearDownTests()
        {
            CommonHelpers.CloseApplication("CalculatorApp");
        }

        [AfterTestRun]
        static void CloseWinAppDriver()
        {
            CommonHelpers.CloseApplication("CalculatorApp");
            WinAppDriverHelper.CloseWinAppDriver();
        }
    }
}
