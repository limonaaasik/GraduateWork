using GraduateWork.Helpers.Configuration;
using GraduateWork.Helpers;
using OpenQA.Selenium;
using GraduateWork.Helpers;
using GraduateWork.Helpers.Configuration;

namespace GraduateWork.Pages;

public abstract class BasePage
{
    protected IWebDriver Driver { get; private set; }
    protected WaitsHelper WaitsHelper { get; private set; }

    public BasePage(IWebDriver driver)
    {
        Driver = driver;
        WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));
    }

    public BasePage(IWebDriver driver, bool openPageByUrl)
    {
        Driver = driver;
        WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));

        if (openPageByUrl)
        {
            OpenPageByURL();
        }
    }

    protected abstract string GetEndpoint();
    public abstract bool IsPageOpened();

    protected void OpenPageByURL()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL + GetEndpoint());
    }
}