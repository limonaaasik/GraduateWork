using GraduateWork.Elements;

namespace GraduateWork.Models;

public class TestCase
{
    public required string Title { get; set; }
    public required DropDown Status { get; set; }
    public required DropDown Severity { get; set; }
    public required DropDown Priority { get; set; }
    public required DropDown Type { get; set; }
    public required DropDown Layer { get; set; }
    public required DropDown IsFlaky { get; set; }
    public required DropDown Behavior { get; set; }
    public required DropDown AutomationStatus { get; set; }
    public required Button Save { get; set; }
    public required string ProjectId { get; set; }

}