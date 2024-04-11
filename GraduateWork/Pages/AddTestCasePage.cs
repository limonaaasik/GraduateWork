using GraduateWork.Elements;
using OpenQA.Selenium;

namespace GraduateWork.Pages
{
    public class AddTestCasePage(IWebDriver? driver, bool openByURL, string projectCode) : BasePage(driver, openByURL)
    {
        private string END_POINT = $"icase/{projectCode}/create";

        // Описание элементов
        private static readonly By _titleInputBy = By.ClassName("DcqLJ3");
        private static readonly By _textBy = By.XPath("//*[text()='Basic']");

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        protected override bool EvaluateLoadedStatus()
        {
            return WaitsHelper.WaitForVisibilityLocatedBy(_textBy).Displayed;
        }

        // Атомарные Методы
 
    }
}
