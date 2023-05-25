using SeleniumUiTests.ApplicationModel;
using TechTalk.SpecFlow;

namespace SeleniumUiTests.Steps
{
    [Binding]
    class SettingsWindowSteps
    {
        private SettingsWindow _settingsWindow;

        SettingsWindowSteps(SettingsWindow settingsWindow)
        {
            _settingsWindow = settingsWindow;
        }

        [Then(@"Verify application version")]
        public void ThenVerifyApplicationVersion()
        {
            _settingsWindow.VerifyApplicationVersionText();
        }
    }
}
