using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using SeleniumUiTests.Helpers;
using System;
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
        private string numAutomationId;

        private WindowsElement CalculatorWindow => _calculatorWindow ??=
            ApplicationDriver.CalculatorSession.FindElementWait(MobileBy.Name("Calculator"));

        private WindowsElement CalculatorWindowTitle => CalculatorWindow.FindElementWait(MobileBy.AccessibilityId("AppName"));
        private WindowsElement OpenNavigationButton => CalculatorWindow.FindElementWait(MobileBy.Name("Open Navigation"));
        private WindowsElement HistoryButton => CalculatorWindow.FindElementWait(MobileBy.AccessibilityId("HistoryButton"));
        private WindowsElement HistoryEmptyText => CalculatorWindow.FindElementWait(MobileBy.AccessibilityId("HistoryEmpty"));
        private WindowsElement VarNumberButton => CalculatorWindow.FindElementWait(MobileBy.AccessibilityId($"{numAutomationId}"));

        private WindowsElement PlusButton => CalculatorWindow.FindElementWait(MobileBy.AccessibilityId("plusButton"));
        private WindowsElement MinusButton => CalculatorWindow.FindElementWait(MobileBy.AccessibilityId("minusButton"));
        private WindowsElement EqualsButton => CalculatorWindow.FindElementWait(MobileBy.AccessibilityId("equalButton"));
        private WindowsElement CalculatorResultsText => CalculatorWindow.FindElementWait(MobileBy.AccessibilityId("CalculatorResults"));
        private WindowsElement HistoryListViewItems => ApplicationDriver.CalculatorSession.FindElementWait(MobileBy.AccessibilityId("HistoryListView"));

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

        public void ClickHistoryButton()
        {
            HistoryButton.ClickAndLog(nameof(HistoryButton), _specFlowOutputHelper);
        }

        public void VerifyHistoryIsEmpty()
        {
            var expectedText = "There’s no history yet";

            Assert.AreEqual(expectedText, HistoryEmptyText.Text);
            _specFlowOutputHelper.WriteLine($"{HistoryEmptyText.Text} is equals to {expectedText}");
        }

        public void AddNumbersTogether(int firstNumb, int secondNum)
        {
            ConvertNumberToAutomationId(firstNumb);
            VarNumberButton.ClickAndLog(nameof(VarNumberButton), _specFlowOutputHelper);
            PlusButton.ClickAndLog(nameof(PlusButton), _specFlowOutputHelper);
            ConvertNumberToAutomationId(secondNum);
            VarNumberButton.ClickAndLog(nameof(VarNumberButton), _specFlowOutputHelper);
        }

        public void MinusNumbersTogether(int firstNumb, int secondNum)
        {
            ConvertNumberToAutomationId(firstNumb);
            VarNumberButton.ClickAndLog(nameof(VarNumberButton), _specFlowOutputHelper);
            MinusButton.ClickAndLog(nameof(MinusButton), _specFlowOutputHelper);
            ConvertNumberToAutomationId(secondNum);
            VarNumberButton.ClickAndLog(nameof(VarNumberButton), _specFlowOutputHelper);
        }

        public void VarOperationNumbersTogether(string operation, string firstNum, string secondNum)
        {
            ConvertNumberToAutomationId(Convert.ToInt32(firstNum));
            VarNumberButton.ClickAndLog(nameof(VarNumberButton), _specFlowOutputHelper);
            ConvertOperationToAutomationId(operation);
            VarNumberButton.ClickAndLog(nameof(VarNumberButton), _specFlowOutputHelper);
            ConvertNumberToAutomationId(Convert.ToInt32(secondNum));
            VarNumberButton.ClickAndLog(nameof(VarNumberButton), _specFlowOutputHelper);
        }

        public void VerifyCalculatorResult(string expectedResult)
        {
            EqualsButton.ClickAndLog(nameof(EqualsButton), _specFlowOutputHelper);

            // Removes 'Display is' text
            var trimmedResultsText = CalculatorResultsText.Text.Remove(0, 11);

            Assert.AreEqual(expectedResult.ToString(), trimmedResultsText);
            _specFlowOutputHelper.WriteLine($"{CalculatorResultsText.Text} is equals to {expectedResult}");
        }

        public void VerifyHistory(string expectedResult)
        {
            var resultListItems = HistoryListViewItems.FindElements(MobileBy.XPath("//ListItem"));
            var resultListItem = resultListItems[0].FindElementWait(MobileBy.ClassName("NamedContainerAutomationPeer"));
            //var resultListItemTwo = resultListItem.FindElementWait(MobileBy.XPath("//Text"));

            Assert.AreEqual(expectedResult, resultListItem.Text);
        }

        private void ConvertNumberToAutomationId(int number)
        {
            numAutomationId = number switch
            {
                0 => "num0Button",
                1 => "num1Button",
                2 => "num2Button",
                3 => "num3Button",
                4 => "num4Button",
                5 => "num5Button",
                6 => "num6Button",
                7 => "num7Button",
                8 => "num8Button",
                9 => "num9Button",
                _ => "INVALID",
            };
        }

        private void ConvertOperationToAutomationId(string operation)
        {
            numAutomationId = operation switch
            {
                "+" => "plusButton",
                "-" => "minusButton",
                "*" => "multiplyButton",
                "/" => "divideButton",
                _ => "INVALID",
            };
        }
    }
}
