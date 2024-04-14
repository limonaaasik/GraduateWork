using GraduateWork.Models;
using GraduateWork.Pages;
using OpenQA.Selenium;

namespace GraduateWork.Steps;

public class TestCaseSteps : BaseSteps
{
    public TestCaseSteps(IWebDriver driver) : base(driver)
    {
    }

    public DashboardPage AddTestCase(TestCase testCase, string projectCode)
    {
        AddTestCasePage addTestCase = new AddTestCasePage(Driver, false, projectCode);
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
}