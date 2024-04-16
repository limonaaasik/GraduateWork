using GraduateWork.Models;
using GraduateWork.Pages;

namespace GraduateWork.Tests.GUITests;

public class RemoveTestCaseTest : BaseTest
{
    [Test]
    public void SuccessfulDeleteTestCase()
    {
        ProjectsPage projectPage = _userSteps.SuccessfulLogin(Admin);
        Assert.That(projectPage.IsPageOpened);

        DashboardPage dashboard = _userSteps.OpenDEMOProject();
        Assert.That(dashboard.IsPageOpened);

        // добавление  теста
        AddTestCasePage testCasePage = _userSteps.ClickAddButton();

        TestCase expectedTestCase = new TestCase.Builder()
            .SetTitle("New TestCase Makusheva")
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
        Thread.Sleep(2000);

        // сам тест на удаление
        _testCaseSteps.DeleteTestCase(expectedTestCase);
        Thread.Sleep(500);  // после удаления элемент удаляется не сразу, нужно время
        Assert.That(dashboard.IsTestCaseDeleted(expectedTestCase.Title));

    }
}