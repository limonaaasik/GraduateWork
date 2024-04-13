using OpenQA.Selenium;

namespace GraduateWork.Elements
{
    public class DropDown
    {
        private UIElement _uiElement;
        private IWebDriver _webDriver;
        private string _locatorDropDownTemplate = "//div[contains(@class, 'FlenM')][text()='{0}']";

        public DropDown(IWebDriver webDriver, By by)
        {
            _uiElement = new UIElement(webDriver, by);
            _webDriver = webDriver;
        }

        public DropDown(IWebDriver webDriver, IWebElement webElement)
        {
            _uiElement = new UIElement(webDriver, webElement);
            _webDriver = webDriver;
        }

        public void SelectByText(string text)
        {
            _uiElement.Click();
            UIElement dropDownElement = new UIElement(_webDriver, By.XPath(string.Format(_locatorDropDownTemplate, text)));
            if (dropDownElement.Displayed) 
            {
                dropDownElement.Click();
            }
        }
    }
}
