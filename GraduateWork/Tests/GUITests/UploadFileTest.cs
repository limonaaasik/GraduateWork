using GraduateWork.Pages;
using OpenQA.Selenium;
using System.Reflection;

namespace GraduateWork.Tests.GUITests;

public class UploadFileTest : BaseTest
{
    [Test]
    public void SuccessfulUploadTest()
    {
        ProjectsPage projectPage = _userSteps.SuccessfulLogin(Admin);
        Assert.That(projectPage.IsPageOpened);

        DashboardPage dashboard = _userSteps.OpenDEMOProject();
        Assert.That(dashboard.IsPageOpened);

        AddTestCasePage addTestCasePage = _userSteps.ClickAddButton();
        addTestCasePage.AddAttachmentButton.Click();
        //addTestCasePage.DropZone.Click();

        // Получаем путь к исполняемому файлу (exe)
        string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        // Конструируем путь к файлу внутри проекта
        string filePath = Path.Combine(assemblyPath, "Resources", "cat_picture.jpg");

        addTestCasePage.DropZone.SendKeys(filePath);

        IWebElement uploadedFile = _waitsHelper.WaitForExists(By.XPath("//span[text() = 'cat_picture.jpg']"));

        Assert.That(uploadedFile.Displayed);
    }
}