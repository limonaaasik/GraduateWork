using Allure.NUnit.Attributes;
using GraduateWork.Pages;
using OpenQA.Selenium;

namespace GraduateWork.Tests.GUITests;

[AllureSuite("Suite: GUI Tests")]
public class ModalWindowTest : BaseTest
{
    [Test]
    [AllureDescription("“ест на проверку отображени€ диалогового окна")]
    public void SuccessfulDisplayedModalWindow()
    {
        ProjectsPage projectPage = _userSteps.SuccessfulLogin(Admin);
        Assert.That(projectPage.IsPageOpened);

        DashboardPage dashboard = _userSteps.OpenDEMOProject();
        Assert.That(dashboard.IsPageOpened);

        AddTestCasePage testCasePage = _userSteps.ClickAddButton();
        testCasePage.AddAttachmentButton.Click();
        Assert.That(testCasePage.ModalWindow.Displayed);

        string modalWindowTitle = testCasePage.ModalWindow.FindElement(By.XPath("//h3[text()='Upload attachment']")).Text;
        Assert.That(modalWindowTitle, Is.EqualTo("Upload attachment"));

    }
}