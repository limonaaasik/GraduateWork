//using Allure.NUnit.Attributes;
//using GraduateWork.Helpers.Configuration;
//using GraduateWork.Models;
//using GraduateWork.Pages;

//namespace GraduateWork.Tests.GUITests;

//[AllureSuite("Suite: GUI Tests")]
//public class ReproductionBugTest : BaseTest
//{
//    [Test]
//    [AllureDescription("Тест воспроизводящий дефект при логировании")]
//    public void ReproductionBugLoginTestCase()
//    {
//        User admin = new User
//        {
//            Email = Configurator.AppSettings.Username,
//            Password = "lakaklakal67856"
//        };

//        ProjectsPage projectPage = _userSteps.SuccessfulLogin(admin);
//        Assert.That(projectPage.IsPageOpened);
//    }
//}