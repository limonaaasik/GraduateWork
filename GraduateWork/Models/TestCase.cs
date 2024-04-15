namespace GraduateWork.Models;

public class TestCase
{
    public string Title { get; set; }
    public string Status { get; set; }
    public string Severity { get; set; }
    public string Priority { get; set; }
    public string Type { get; set; }
    public string Layer { get; set; }
    public string IsFlaky { get; set; }
    public string Behavior { get; set; }
    public string AutomationStatus { get; set; }

    private TestCase(string title, string status, string severity, string priority, string type, string layer, string isFlaky, string behavior, string automationStatus)
    {
        Title = title;
        Status = status;
        Severity = severity;
        Priority = priority;
        Type = type;
        Layer = layer;
        IsFlaky = isFlaky;
        Behavior = behavior;
        AutomationStatus = automationStatus;
    }

    public class Builder()
    {
        public string Title { get; set; }
        public string Status { get; set; }
        public string Severity { get; set; }
        public string Priority { get; set; }
        public string Type { get; set; }
        public string Layer { get; set; }
        public string IsFlaky { get; set; }
        public string Behavior { get; set; }
        public string AutomationStatus { get; set; }

        public Builder SetTitle(string title)
        {
            Title = title;
            return this;
        }

        public Builder SetStatus(string status)
        {
            Status = status;
            return this;
        }
        public Builder SetSeverity(string severity)
        {
            Severity = severity;
            return this;
        }
        public Builder SetPriority(string priority)
        {
            Priority = priority;
            return this;
        }
        public Builder SetType(string type)
        {
            Type = type;
            return this;
        }
        public Builder SetLayer(string layer)
        {
            Layer = layer;
            return this;
        }
        public Builder SetFlaky(string flaky)
        {
            IsFlaky = flaky;
            return this;
        }
        public Builder SetBehavior(string behavior)
        {
            Behavior = behavior;
            return this;
        }

        public Builder SetAutomationStatus(string automationStatus)
        {
            AutomationStatus = automationStatus;
            return this;
        }

        public TestCase Build()
        {
            return new TestCase(Title, Status, Severity, Priority, Type, Layer,
                IsFlaky, Behavior, AutomationStatus);
        }
    }
}

