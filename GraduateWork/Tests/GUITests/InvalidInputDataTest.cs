using Allure.NUnit.Attributes;
using GraduateWork.Helpers.Configuration;
using GraduateWork.Pages;

namespace GraduateWork.Tests.GUITests;

[AllureSuite("Suite: GUI Tests")]
public class InvalidInputDataTest : BaseTest
{
    [Test]
    [AllureDescription("Тест на проверку использования некорректных данных")]
    public void IncorrectLoginTestCase()
    {
        LoginPage projectPage = _userSteps.IncorrectLogin(Configurator.AppSettings.Username, "lavaslava298*");
        Assert.That(projectPage.IsPageOpened);
    }
}