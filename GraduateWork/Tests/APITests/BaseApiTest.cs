using GraduateWork.Services;
using NLog;
using GraduateWork.Clients;

namespace TestRaGraduateWorkilComplexApi.Tests;

public class BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    protected AttachmentService? AttachmentService;
    
    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended();
        AttachmentService = new AttachmentService(restClient);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        AttachmentService?.Dispose();
    }
}