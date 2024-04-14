using OpenQA.Selenium;

namespace GraduateWork.Steps;

public class BaseSteps
{
    protected IWebDriver Driver;

    public BaseSteps(IWebDriver driver)
    {
        Driver = driver;
    }
}