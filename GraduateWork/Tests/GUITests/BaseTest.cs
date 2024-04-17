using GraduateWork.Core;
using GraduateWork.Helpers.Configuration;
using OpenQA.Selenium;
using GraduateWork.Models;
using GraduateWork.Steps;
using Allure.NUnit;
using GraduateWork.Helpers;
using Allure.Net.Commons;

namespace GraduateWork.Tests.GUITests;

[Parallelizable(scope: ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[AllureNUnit]
public class BaseTest
{
    protected IWebDriver Driver { get; private set; }

    protected UserSteps _userSteps;
    protected TestCaseSteps _testCaseSteps;
    protected WaitsHelper _waitsHelper;

    protected User Admin { get; private set; }

    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;

        _waitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));
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
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            byte[] scrBytes = screenshot.AsByteArray;

            AllureApi.AddAttachment("errorScreenShot", "image/png", scrBytes);
        }

        Driver.Quit();
    }
}