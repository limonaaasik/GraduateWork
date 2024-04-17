using OpenQA.Selenium;
using GraduateWork.Pages;
using GraduateWork.Models;
using GraduateWork.Models;

namespace GraduateWork.Steps;

public class UserSteps : BaseSteps
{
    private LoginPage _loginPage;
    private ProjectsPage _projectsPage;
    private DashboardPage _dashboardPage;
    
    public UserSteps(IWebDriver driver) : base(driver)
    {
        _loginPage = new LoginPage(Driver);
        _projectsPage = new ProjectsPage(Driver);
        _dashboardPage = new DashboardPage(Driver);
    }

    // Комплексные
    public ProjectsPage SuccessfulLogin(User user)
    {
        _loginPage.EmailInput.SendKeys(user.Email);
        _loginPage.PswInput.SendKeys(user.Password);
        _loginPage.ClickLoginInButton();

        return new ProjectsPage(Driver);
    }

    public LoginPage IncorrectLogin(string username, string password)
    {
        _loginPage.EmailInput.SendKeys(username);
        _loginPage.PswInput.SendKeys(password);
        _loginPage.LoginInButton.Click();

        return _loginPage;
    }

    public DashboardPage OpenDEMOProject()
    {
        _projectsPage.ClickProjectLink();
        return new DashboardPage(Driver);
    }

    public AddTestCasePage ClickAddButton()
    {
        _dashboardPage.ClickAddTestCaseButton();
        return new AddTestCasePage(Driver, false);
    }
}