using Allure.NUnit.Attributes;
using GraduateWork.Models;
using GraduateWork.Pages;

namespace GraduateWork.Tests.GUITests;

[AllureSuite("Suite: GUI Tests")]
public class LimitValuesTest : BaseTest
{
    [Test]
    [AllureDescription("�������� ��������� ��������. ���������� ���� 1 - 255 ��������.")]
    public void CheckLimitValue()
    {
        ProjectsPage projectPage = _userSteps.SuccessfulLogin(Admin);
        Assert.That(projectPage.IsPageOpened);

        DashboardPage dashboard = _userSteps.OpenDEMOProject();
        Assert.That(dashboard.IsPageOpened);

        AddTestCasePage addTestCasePage = _userSteps.ClickAddButton();

        // ������� ����� 1-255 ��������
        // �������� ����� 255 ��������
        TestCase expectedTestCase255Title = new TestCase.Builder()
            .SetTitle("fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")
            .Build();

        _testCaseSteps.AddTestCase(expectedTestCase255Title);

        Assert.That(dashboard.IsPageOpened);
        Assert.That(dashboard.IsTestCaseAdded(expectedTestCase255Title.Title));

        // ��������� ����� 254 ��������
        TestCase expectedTestCase254Title = new TestCase.Builder()
            .SetTitle("ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")
            .Build();

        _userSteps.ClickAddButton();
        _testCaseSteps.AddTestCase(expectedTestCase254Title);

        Assert.That(dashboard.IsPageOpened);
        Assert.That(dashboard.IsTestCaseAdded(expectedTestCase254Title.Title));

        // �������� ����� 256 �������� + 1 ���� �� ���� ������ ����������� ����������
        TestCase expectedTestCase256Title = new TestCase.Builder()
            .SetTitle("ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")
            .Build();

        _userSteps.ClickAddButton();
        _testCaseSteps.AddTestCase(expectedTestCase256Title);

        Assert.That(addTestCasePage.ErrorText.Displayed);

        // �������� ����� 0 ��������
        TestCase expectedTestCase0Title = new TestCase.Builder()
            .Build();

        _testCaseSteps.AddTestCase(expectedTestCase0Title);
        Assert.That(addTestCasePage.IsPageOpened());

        // ��������� ����� 1 ������
        TestCase expectedTestCase1Title = new TestCase.Builder()
            .SetTitle("k")
            .Build();

        _testCaseSteps.AddTestCase(expectedTestCase1Title);

        Assert.That(dashboard.IsPageOpened);
        Assert.That(dashboard.IsTestCaseAdded(expectedTestCase1Title.Title));

        // ��������� ����� 2 �������
        TestCase expectedTestCase2Title = new TestCase.Builder()
            .SetTitle("ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")
            .Build();

        _userSteps.ClickAddButton();
        _testCaseSteps.AddTestCase(expectedTestCase2Title);

        Assert.That(dashboard.IsPageOpened);
        Assert.That(dashboard.IsTestCaseAdded(expectedTestCase2Title.Title));
    }
}