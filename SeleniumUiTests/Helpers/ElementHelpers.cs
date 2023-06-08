using OpenQA.Selenium.Appium.Windows;
using System.Drawing;
using TechTalk.SpecFlow.Infrastructure;

namespace SeleniumUiTests.Helpers
{
    internal class ElementHelpers
    {
        public enum Location
        {
            Top,
            Left,
            Right,
            Bottom,
            Center,
        }
        public static Size GetSpecificLocationOfElement(WindowsElement windowsElement, Location location, ISpecFlowOutputHelper outputHelper)
        {
            int Height;
            int Width;

            var locations = windowsElement.Size;

            switch (location)
            {
                case Location.Top:
                    Width = locations.Width / 2;
                    Height = 2;
                    break;
                case Location.Left:
                    Width = 2;
                    Height = locations.Height / 2;
                    break;
                case Location.Right:
                    Width = locations.Width - 2;
                    Height = locations.Height / 2;
                    break;
                case Location.Bottom:
                    Width = locations.Width / 2;
                    Height = locations.Height - 2;
                    break;
                case Location.Center:
                    Width = locations.Width / 2;
                    Height = locations.Height / 2;
                    break;
                default:
                    // returns default 
                    Width = locations.Width;
                    Height = locations.Height;
                    break;
            }

            var size = new Size();
            locations.Height = Height;
            locations.Width = Width;

            outputHelper.WriteLine($"Getting location: {location} of element (Width = {Width} and Height = {Height})");

            return size;
        }
    }
}
