using GraduateWork.Elements;
using OpenQA.Selenium;
using System.Xml.Linq;

namespace GraduateWork.Pages
{
    public class DashboardPage : BasePage
    {
        private static string END_POINT = "projects?status=%5B\"active\"%5D";

        private static readonly By _titleTextBy = By.ClassName("pOpqJc");
        private static readonly By _addTestCaseButtonBy = By.Id("create-case-button");

        public DashboardPage(IWebDriver driver) : base(driver)
        {
        }

        public override bool IsPageOpened()
        {
            return TitleText.Displayed;
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public UIElement TitleText => new UIElement(Driver, _titleTextBy);
        public UIElement AddTestCaseButton => new UIElement(Driver, _addTestCaseButtonBy);

        public void ClickAddTestCaseButton()
        {
            AddTestCaseButton.Click();
        }

        public bool IsTestCaseAdded(string name)
        {
            By titleTestBy = By.XPath($"//*[text()='{name}']");
            UIElement TitleTest = new UIElement(Driver, titleTestBy);
            return TitleTest.Displayed;
        }
    }
}
