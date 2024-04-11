namespace GraduateWork.Models;

public class Project
{
    public string ProjectName { get; set; }
    public string Announcement { get; set; }
    public bool IsShowAnnouncement { get; set; }
    public int ProjectTypeINT { get; set; }
    public string ProjectTypeSTRING { get; set; }
    public bool IsTestCaseApprovals { get; set; }
}