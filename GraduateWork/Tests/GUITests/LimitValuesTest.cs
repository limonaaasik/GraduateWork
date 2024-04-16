using Allure.NUnit.Attributes;
using GraduateWork.Elements;
using GraduateWork.Models;
using GraduateWork.Pages;
using OpenQA.Selenium;

namespace GraduateWork.Tests.GUITests;

public class LimitValuesTest : BaseTest
{
    [Test]
    [AllureDescription("Проверка ввода 255 символов - граничное значение")]
    public void CheckLimitValue()
    {
        ProjectsPage projectPage = _userSteps.SuccessfulLogin(Admin);
        Assert.That(projectPage.IsPageOpened);

        DashboardPage dashboard = _userSteps.OpenDEMOProject();
        Assert.That(dashboard.IsPageOpened);

        AddTestCasePage testCasePage = _userSteps.ClickAddButton();

        // границы ввода 1-255 символов
        // проверка ввода 255 символов
        TestCase expectedTestCase255Title = new TestCase.Builder()
            .SetTitle("fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")
            .Build();

        _testCaseSteps.AddTestCase(expectedTestCase255Title);

        Assert.That(dashboard.IsPageOpened);
        Assert.That(dashboard.IsTestCaseAdded(expectedTestCase255Title.Title));

        // провекрка ввода 254 символов
        TestCase expectedTestCase254Title = new TestCase.Builder()
            .SetTitle("ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")
            .Build();

        _userSteps.ClickAddButton();
        _testCaseSteps.AddTestCase(expectedTestCase254Title);

        Assert.That(dashboard.IsPageOpened);
        Assert.That(dashboard.IsTestCaseAdded(expectedTestCase254Title.Title));

        // проверка ввода 256 символов
        TestCase expectedTestCase256Title = new TestCase.Builder()
            .SetTitle("fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")
            .Build();

        _userSteps.ClickAddButton();
        _testCaseSteps.AddTestCase(expectedTestCase256Title);

        UIElement errorText = new UIElement(Driver, By.XPath("//div[text()='The title may not be greater than 255 characters.']"));
        Assert.That(errorText.Displayed);

        // проверка ввода 0 символов
        TestCase expectedTestCase0Title = new TestCase.Builder()
            .SetStatus("Draft")
            .Build();

        _testCaseSteps.AddTestCase(expectedTestCase0Title);
        Assert.That(testCasePage.IsPageOpened());

        // провекрка ввода 1 символ
        TestCase expectedTestCase1Title = new TestCase.Builder()
            .SetTitle("k")
            .Build();

        _testCaseSteps.AddTestCase(expectedTestCase1Title);

        Assert.That(dashboard.IsPageOpened);
        Assert.That(dashboard.IsTestCaseAdded(expectedTestCase1Title.Title));

        // провекрка ввода 2 символа
        TestCase expectedTestCase2Title = new TestCase.Builder()
            .SetTitle("ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")
            .Build();

        _userSteps.ClickAddButton();
        _testCaseSteps.AddTestCase(expectedTestCase2Title);

        Assert.That(dashboard.IsPageOpened);
        Assert.That(dashboard.IsTestCaseAdded(expectedTestCase2Title.Title));
    }
}