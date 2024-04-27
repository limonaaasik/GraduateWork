using GraduateWork.Models;
using TestRaGraduateWorkilComplexApi.Tests;

namespace GraduateWork.Tests.APITests
{
    public class AttachmentTests : BaseApiTest
    {
        private Attachments? _attachments;

        [Test]
        public void GetAllAttachmentsTest()
        {
            var attachments = AttachmentService.GetAttachments().Result;
            Assert.That(attachments.Status, Is.True);
            
            _attachments = attachments;
        }

        [Test]
        public void GetAttachmentByHashTest() 
        {
            string hash = _attachments.Result.Entities.ElementAt(0).Hash;
            var attachment = AttachmentService.GetAttachmentByHash(hash).Result;

            Assert.That(attachment.Status);
            Assert.That(attachment.Result.Hash, Is.EqualTo(hash));
        }

        [Test]
        public void UploadAttachmentTest()
        {
            string fileName = "cat_picture.jpg";
            string path = $"Resources/{fileName}";

            var uploadAttachment = AttachmentService.UploadAttachment(path).Result;

            Assert.Multiple(() =>
            {
                Assert.That(uploadAttachment.Status, Is.True);
                Assert.That(uploadAttachment.Result.ElementAt(0).FileName, Is.EqualTo(fileName));
            });
        }

        // AFE GET-тест. Вводим хэш аттачмента int вместо string
        [Test]
        public void GetAttachmentByHashNegativeTest()
        {
            string hash = "1289";
            var attachment = AttachmentService.GetAttachmentByHash(hash).Result;

            Assert.That(attachment.Status, Is.False);
            Assert.That(attachment.ErrorMessage, Is.EqualTo("Attachment not found"));
        }
    }
}
