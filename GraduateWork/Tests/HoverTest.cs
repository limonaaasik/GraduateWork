using GraduateWork.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace GraduateWork.Tests;

public class HoverTest : BaseTest
{
    [Test]
    public void SuccessfulDisplayedHover()
    {
        ProjectsPage projectPage = _userSteps.SuccessfulLogin(Admin);
        Assert.That(projectPage.IsPageOpened);

        DashboardPage dashboard = _userSteps.OpenDEMOProject();
        Assert.That(dashboard.IsPageOpened);

        Actions actions = new Actions(Driver);
        actions.MoveToElement(dashboard.CollapseButton, 10, 10).Perform();

        string collapseButtonText = Driver.FindElement(By.XPath("//div[text()='Collapse all suites']")).Text;
        Assert.That(collapseButtonText, Is.EqualTo("Collapse all suites"));
    }
}