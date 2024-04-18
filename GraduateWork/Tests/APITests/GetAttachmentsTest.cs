using GraduateWork.Models;
using TestRaGraduateWorkilComplexApi.Tests;

namespace GraduateWork.Tests.APITests
{
    public class GetAttachmentsTest : BaseApiTest
    {
        private Attachments _attachments;

        [Test]
        public void GetAllAttachmentsTest()
        {
            var attachments = AttachmentService.GetAttachments();
            Assert.That(attachments.Result.Result.Total, Is.EqualTo(9));
        }
    }
}
