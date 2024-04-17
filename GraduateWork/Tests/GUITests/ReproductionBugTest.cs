using GraduateWork.Helpers.Configuration;
using GraduateWork.Models;
using GraduateWork.Pages;

namespace GraduateWork.Tests.GUITests;

public class ReproductionBugTest : BaseTest
{
    [Test]
    public void ReproductionBugLoginTestCase()
    {
        User admin = new User
        {
            Email = Configurator.AppSettings.Username,
            Password = "lakaklakal67856"
        };

        ProjectsPage projectPage = _userSteps.SuccessfulLogin(admin);
        Assert.That(projectPage.IsPageOpened);
    }
}