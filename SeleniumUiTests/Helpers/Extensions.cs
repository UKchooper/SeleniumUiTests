using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow.Infrastructure;

namespace SeleniumUiTests.Helpers
{
    public static class Extensions
    {
        public const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        public const int DefaultTimeoutSeconds = 20;
        public const int DefaultPollingIntervalMilliseconds = 250;

        public static WindowsElement FindElementWait<T>(
            this T context,
            By specifier,
            int secondsTimeout = DefaultTimeoutSeconds,
            int pollingInterval = DefaultPollingIntervalMilliseconds,
            bool includeHidden = false
        ) where T : ISearchContext
        {
            return Wait(context, secondsTimeout, pollingInterval)
                .Until(d =>
                {
                    var findElement = d.FindElement(specifier);
                    return (includeHidden || findElement.Displayed) && findElement.Enabled ? findElement : null;
                }) as WindowsElement;
        }

        private static DefaultWait<T> Wait<T>(T context, int secondsTimeout, int pollingInterval)
        {
            var wait = new DefaultWait<T>(context);
            wait.IgnoreExceptionTypes(
                typeof(NoSuchElementException),
                typeof(StaleElementReferenceException),
                typeof(ElementClickInterceptedException),
                typeof(WebDriverException)
            );
            wait.Timeout = TimeSpan.FromSeconds(secondsTimeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(pollingInterval);
            return wait;
        }

        public static bool WaitUntilCondition<T>(
        this T context,
        Func<T, bool> condition,
        int secondsTimeout = DefaultTimeoutSeconds,
        int pollingInterval = DefaultPollingIntervalMilliseconds
        ) where T : ISearchContext
        {
            try
            {
                return Wait(context, secondsTimeout, pollingInterval)
                    .Until(_ => condition(context));
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Click and report to living document
        /// </summary>
        /// <param name="uiElement"></param>
        /// <param name="elementName"></param>
        /// <param name="outputHelper"></param>
        public static void ClickAndLog(this WindowsElement uiElement, string elementName, ISpecFlowOutputHelper outputHelper)
        {
            outputHelper.WriteLine($"Clicked {elementName} at location {uiElement.Location}");
            uiElement.Click();
        }

        /// <summary>
        /// SendKeys and report to living document
        /// </summary>
        /// <param name="uiElement"></param>
        /// <param name="text"></param>
        /// <param name="elementName"></param>
        /// <param name="outputHelper"></param>
        public static void SendKeysAndLog(this WindowsElement uiElement, string text, string elementName, ISpecFlowOutputHelper outputHelper)
        {
            outputHelper.WriteLine($"Entered {text} into {elementName} at location {uiElement.Location}");
            uiElement.SendKeys(text);
        }
    }
}
