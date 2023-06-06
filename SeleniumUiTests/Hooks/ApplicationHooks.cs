using SeleniumUiTests.Helpers;
using TechTalk.SpecFlow;

namespace SeleniumUiTests.Hooks
{
    [Binding]
    class ApplicationHooks
    {
        //[BeforeTestRun]
        //static void SetupTests()
        //{
        //    ApplicationDriver.LaunchCalculator();
        //}

        [AfterScenario]
        [AfterTestRun]
        static void TearDownTests()
        {
            CommonHelpers.CloseApplication("CalculatorApp");
        }
    }
}
