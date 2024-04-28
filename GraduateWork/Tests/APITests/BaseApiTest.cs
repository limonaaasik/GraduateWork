using GraduateWork.Services;
using NLog;
using GraduateWork.Clients;

namespace TestRaGraduateWorkilComplexApi.Tests;

public class BaseApiTest
{
    protected AttachmentService? AttachmentService;
    protected ProjectService? ProjectService;
    
    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended();
        AttachmentService = new AttachmentService(restClient);
        ProjectService = new ProjectService(restClient);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        AttachmentService?.Dispose();
        ProjectService?.Dispose();
    }
}