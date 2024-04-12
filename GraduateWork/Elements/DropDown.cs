using OpenQA.Selenium;

namespace GraduateWork.Elements
{
    public class DropDown
    {
        private UIElement _uiElement;

        public DropDown(IWebDriver webDriver, By by)
        {
            _uiElement = new UIElement(webDriver, by);
        }

        public DropDown(IWebDriver webDriver, IWebElement webElement)
        {
            _uiElement = new UIElement(webDriver, webElement);
        }
    }
}
