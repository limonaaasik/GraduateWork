using OpenQA.Selenium;
using GraduateWork.Elements;

namespace GraduateWork.Pages
{
    public class LoginPage : BasePage
    {
        private static string END_POINT = "login";

        // Описание элементов
        private static readonly By EmailInputBy = By.CssSelector("input[placeholder='Work email']");
        private static readonly By PswInputBy = By.CssSelector("input[placeholder='Password']");
        private static readonly By RememberMeCheckboxBy = By.CssSelector("input[name='remember']");
        private static readonly By LoginInButtonBy = By.CssSelector(".exOCAW.Ipyboe");

        // Инициализация класса
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public override bool IsPageOpened()
        {
            return LoginInButton.Displayed && EmailInput.Displayed;
        }

        // Методы
        // Методы поиска элементов
        public IWebElement EmailInput => WaitsHelper.WaitForExists(EmailInputBy);
        public IWebElement PswInput => WaitsHelper.WaitForExists(PswInputBy);
        public IWebElement RememberMeCheckbox => WaitsHelper.WaitForExists(RememberMeCheckboxBy);
        public Button LoginInButton => new Button(Driver, LoginInButtonBy);
        
        // Методы действий с элементами
        public void ClickLoginInButton() => LoginInButton.Click();
    }
}