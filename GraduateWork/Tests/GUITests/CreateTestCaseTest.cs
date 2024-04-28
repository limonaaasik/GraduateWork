using Allure.NUnit.Attributes;
using GraduateWork.Models;
using GraduateWork.Pages;

namespace GraduateWork.Tests.GUITests;

[AllureSuite("Suite: GUI Tests")]
public class CreateTestCaseTest : BaseTest
{
    [Test]
    [AllureDescription("Тест на проверку создания сущности тест-кейс")]
    public void SuccessfulAddTestCase()
    {
        ProjectsPage projectPage = _userSteps.SuccessfulLogin(Admin);
        Assert.That(projectPage.IsPageOpened);

        DashboardPage dashboard = _userSteps.OpenDEMOProject();
        Assert.That(dashboard.IsPageOpened);

        AddTestCasePage testCasePage = _userSteps.ClickAddButton();

        TestCase expectedTestCase = new TestCase.Builder()
            .SetTitle("Smoke TestCase Makusheva")
            .SetStatus("Draft")
            .SetSeverity("Critical")
            .SetPriority("High")
            .SetType("Smoke")
            .SetLayer("API")
            .SetFlaky("Yes")
            .SetBehavior("Positive")
            .SetAutomationStatus("Manual")
            .Build();

        _testCaseSteps.AddTestCase(expectedTestCase);

        Assert.That(dashboard.IsPageOpened);
        Assert.That(dashboard.IsTestCaseAdded(expectedTestCase.Title));
    }
}