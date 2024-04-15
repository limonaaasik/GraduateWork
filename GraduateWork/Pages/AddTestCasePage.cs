using GraduateWork.Elements;
using OpenQA.Selenium;

namespace GraduateWork.Pages
{
    public class AddTestCasePage(IWebDriver? driver, bool openByURL) : BasePage(driver, openByURL)
    {
        private string END_POINT = $"icase/DEMO/create";

        // Описание элементов
        private static readonly By _titleInputBy = By.ClassName("DcqLJ3");
        private static readonly By _textBy = By.XPath("//*[text()='Basic']");
        private static readonly By _statusDropDownBy = By.CssSelector(".col-xl-4.col-lg-4.col-md-12.col-sm-12.form-group .na4nzw");
        private static readonly By _severityDropDownBy = By.XPath("//label[@for='0-severity']/following::div[1]/div");
        private static readonly By _priorityDropDownBy = By.XPath("//label[@for='0-priority']/following::div[1]/div");
        private static readonly By _typeDropDownBy = By.XPath("//label[@for='0-type']/following::div[1]/div");
        private static readonly By _layerDropDownBy = By.XPath("//label[@for='0-layer']/following::div[1]/div");
        private static readonly By _flakyDropDownBy = By.XPath("//label[@for='0-is_flaky']/following::div[1]/div");
        private static readonly By _behaviorDropDownBy = By.XPath("//label[@for='0-behavior']/following::div[1]/div");
        private static readonly By _automationStatusDropDownBy = By.XPath("//label[@for='0-isManual']/following::div[1]/div");
        private static readonly By _saveButtonDropDownBy = By.CssSelector(".G1dmaA.ecSEF_.IAcAWv");

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public override bool IsPageOpened()
        {
            return WaitsHelper.WaitForVisibilityLocatedBy(_textBy).Displayed;
        }

        // Атомарные Методы
        public UIElement TitlePage => new UIElement(Driver, _textBy);
        public UIElement TitleInput => new UIElement(Driver, _titleInputBy);
        public DropDown StatusDropDown => new DropDown(Driver, _statusDropDownBy);
        public DropDown SeverityDropDown => new DropDown(Driver, _severityDropDownBy);
        public DropDown PriorityDropDown => new DropDown(Driver, _priorityDropDownBy);
        public DropDown TypeDropDown => new DropDown(Driver, _typeDropDownBy);
        public DropDown LayerDropDown => new DropDown(Driver, _layerDropDownBy);
        public DropDown FlakyDropDown => new DropDown(Driver, _flakyDropDownBy);
        public DropDown BehaviorDropDown => new DropDown(Driver, _behaviorDropDownBy);
        public DropDown AutoStatusDropDown => new DropDown(Driver, _automationStatusDropDownBy);
        public UIElement SaveButton => new UIElement(Driver, _saveButtonDropDownBy);
    }
}
