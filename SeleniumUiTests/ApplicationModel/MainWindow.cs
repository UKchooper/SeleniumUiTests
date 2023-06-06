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
        private string numAutomationId;

        private WindowsElement CalculatorWindow => _calculatorWindow ??=
            ApplicationDriver.CalculatorSession.FindElementWait(MobileBy.Name("Calculator"));

        private WindowsElement CalculatorWindowTitle => CalculatorWindow.FindElementWait(MobileBy.AccessibilityId("AppName"));
        private WindowsElement OpenNavigationButton => CalculatorWindow.FindElementWait(MobileBy.Name("Open Navigation"));
        private WindowsElement HistoryButton => CalculatorWindow.FindElementWait(MobileBy.AccessibilityId("HistoryButton"));
        private WindowsElement HistoryEmptyText => CalculatorWindow.FindElementWait(MobileBy.AccessibilityId("HistoryEmpty"));
        private WindowsElement NumberOneButton => CalculatorWindow.FindElementWait(MobileBy.AccessibilityId("num1Button"));
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

        public void VarOperationNumbersTogether(string operation, int firstNumb, int secondNum)
        {
            ConvertNumberToAutomationId(firstNumb);
            VarNumberButton.ClickAndLog(nameof(VarNumberButton), _specFlowOutputHelper);
            ConvertOperationToAutomationId(operation);
            VarNumberButton.ClickAndLog(nameof(VarNumberButton), _specFlowOutputHelper);
            ConvertNumberToAutomationId(secondNum);
            VarNumberButton.ClickAndLog(nameof(VarNumberButton), _specFlowOutputHelper);
        }

        public void VerifyCalculatorResult(string expectedResult)
        {
            EqualsButton.ClickAndLog(nameof(EqualsButton), _specFlowOutputHelper);

            // Removes 'Display is' text
            var trimmedResultsText = CalculatorResultsText.Text.Remove(0, 11);

            Assert.AreEqual(expectedResult.ToString(), trimmedResultsText);
            _specFlowOutputHelper.WriteLine($"{CalculatorResultsText.Text} is equals to {expectedResult.ToString()}");
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
            switch (number)
            {
                case 0:
                    numAutomationId = "num0Button";
                    break;
                case 1:
                    numAutomationId = "num1Button";
                    break;
                case 2:
                    numAutomationId = "num2Button";
                    break;
                case 3:
                    numAutomationId = "num3Button";
                    break;
                case 4:
                    numAutomationId = "num4Button";
                    break;
                case 5:
                    numAutomationId = "num5Button";
                    break;
                case 6:
                    numAutomationId = "num6Button";
                    break;
                case 7:
                    numAutomationId = "num7Button";
                    break;
                case 8:
                    numAutomationId = "num8Button";
                    break;
                case 9:
                    numAutomationId = "num9Button";
                    break;

                default:
                    numAutomationId = "INVALID";
                    break;
            }
        }

        private void ConvertOperationToAutomationId(string operation)
        {
            switch (operation)
            {
                case "+":
                    numAutomationId = "plusButton";
                    break;
                case "-":
                    numAutomationId = "minusButton";
                    break;
                case "*":
                    numAutomationId = "multiplyButton";
                    break;
                case "/":
                    numAutomationId = "divideButton";
                    break;

                default:
                    numAutomationId = "INVALID";
                    break;
            }

        }
    }
}
