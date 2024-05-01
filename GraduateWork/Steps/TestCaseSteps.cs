using GraduateWork.Elements;
using GraduateWork.Models;
using GraduateWork.Pages;
using OpenQA.Selenium;

namespace GraduateWork.Steps;

public class TestCaseSteps : BaseSteps
{
    public TestCaseSteps(IWebDriver driver) : base(driver)
    {
    }

    public DashboardPage AddTestCase(TestCase testCase)
    {
        AddTestCasePage addTestCase = new AddTestCasePage(Driver, false);
        addTestCase.ClearTestCaseTitle();
        addTestCase.TitleInput.SendKeys(testCase.Title);
        addTestCase.StatusDropDown.SelectByText(testCase.Status);
        addTestCase.SeverityDropDown.SelectByText(testCase.Severity);
        addTestCase.PriorityDropDown.SelectByText(testCase.Priority);
        addTestCase.TypeDropDown.SelectByText(testCase.Type);
        addTestCase.LayerDropDown.SelectByText(testCase.Layer);
        addTestCase.FlakyDropDown.SelectByText(testCase.IsFlaky);
        addTestCase.BehaviorDropDown.SelectByText(testCase.Behavior);
        addTestCase.AutoStatusDropDown.SelectByText(testCase.AutomationStatus);
        addTestCase.SaveButton.Click();
        
        return new DashboardPage(Driver);
    }

    public DashboardPage DeleteTestCase(TestCase testCase)
    {
        DashboardPage dashboardPage = new DashboardPage(Driver);

        By titleTestBy = By.XPath($"//*[text()='{testCase.Title}']");
        UIElement TitleTest = new UIElement(Driver, titleTestBy);
        TitleTest.Click();

        dashboardPage.ButtonDelete.Click();

        By deleteDialogButtonBy = By.CssSelector(".G1dmaA.X8bxUI.IAcAWv");
        UIElement DeleteDialogButton = new UIElement(Driver, deleteDialogButtonBy);
        DeleteDialogButton.Click();
        

        return dashboardPage;
    }
}