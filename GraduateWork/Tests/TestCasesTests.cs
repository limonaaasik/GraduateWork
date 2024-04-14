using GraduateWork.Models;
using GraduateWork.Pages;

namespace GraduateWork.Tests;

public class TestCasesTests : BaseTest
{
    [Test]
    public void SuccessfulAddTestCase()
    {
        ProjectsPage projectPage = _userSteps.SuccessfulLogin(Admin);
        Assert.That(projectPage.IsPageOpened);

        DashboardPage dashboard = _userSteps.OpenDEMOProject();
        Assert.That(dashboard.IsPageOpened);

        AddTestCasePage testCasePage = _userSteps.ClickAddButton();
    }
}