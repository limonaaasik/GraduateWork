using GraduateWork.Core;
using GraduateWork.Helpers.Configuration;
using OpenQA.Selenium;
using GraduateWork.Models;
using GraduateWork.Steps;
using Allure.NUnit;

namespace GraduateWork.Tests;

[Parallelizable(scope: ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[AllureNUnit]
public class BaseTest
{
    protected IWebDriver Driver { get; private set; }

    protected UserSteps _userSteps;
    protected TestCaseSteps _testCaseSteps;

    protected User Admin { get; private set; }

    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;

        _userSteps = new UserSteps(Driver);
        _testCaseSteps = new TestCaseSteps(Driver);

        Admin = new User
        {
            Email = Configurator.AppSettings.Username,
            Password = Configurator.AppSettings.Password
        };

        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}