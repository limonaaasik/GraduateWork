using GraduateWork.Models;
using GraduateWork.Pages;
using OpenQA.Selenium;

namespace GraduateWork.Steps;

public class TestCaseSteps : BaseSteps
{
    private AddTestCasePage _addTestCasePage;
    public TestCaseSteps(IWebDriver driver) : base(driver)
    {
    }

    public DashboardPage AddTestCase(TestCase testCase)
    {

        
        return new DashboardPage(Driver);
    }
}