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

        // ����������  �����
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

        // ��� ���� �� ��������
        _testCaseSteps.DeleteTestCase(expectedTestCase);
        Thread.Sleep(500);  // ����� �������� ������� ��������� �� �����, ����� �����
        Assert.That(dashboard.IsTestCaseDeleted(expectedTestCase.Title));

    }
}