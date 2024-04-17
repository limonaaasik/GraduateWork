using GraduateWork.Helpers.Configuration;
using GraduateWork.Pages;

namespace GraduateWork.Tests.GUITests;

public class InvalidInputDataTest : BaseTest
{
    [Test]
    public void IncorrectLoginTestCase()
    {
        LoginPage projectPage = _userSteps.IncorrectLogin(Configurator.AppSettings.Username, "lavaslava298*");
        Assert.That(projectPage.IsPageOpened);
    }
}