using GraduateWork.Elements;
using OpenQA.Selenium;

namespace GraduateWork.Pages
{
    public class ProjectsPage : BasePage
    {
        private static string END_POINT = "projects?status=%5B\"active\"%5D";

        private static readonly By _titleTextBy = By.ClassName("uA6zAY");
        private static readonly By _projectLinkBy = By.CssSelector("a.cx2QU4");

        public ProjectsPage(IWebDriver driver) : base(driver)
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
        public UIElement ProjectLink => new UIElement(Driver, _projectLinkBy);

        public void ClickProjectLink()
        {
            ProjectLink.Click();
        }

    }
}
