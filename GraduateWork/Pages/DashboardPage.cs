using GraduateWork.Elements;
using OpenQA.Selenium;

namespace GraduateWork.Pages
{
    public class DashboardPage : BasePage
    {
        private static string END_POINT = "project/DEMO";

        private static readonly By _titleTextBy = By.ClassName("pOpqJc");
        private static readonly By _addTestCaseButtonBy = By.Id("create-case-button");
        private static readonly By buttonDeleteBy = By.CssSelector($".far.fa-trash");

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
        public Button ButtonDelete => new Button(Driver, buttonDeleteBy);

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

        public bool IsTestCaseDeleted(string name)
        {
            try
            {
                IWebElement isExistTestCase = Driver.FindElement(By.XPath($"//*[text()='{name}']"));
            }
            catch (Exception)
            {
                return true;
            }
            return false;
        }
    }
}
