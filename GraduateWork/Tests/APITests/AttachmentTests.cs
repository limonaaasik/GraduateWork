using Allure.NUnit.Attributes;
using GraduateWork.Models;
using Newtonsoft.Json;
using NLog;
using TestRaGraduateWorkilComplexApi.Tests;

namespace GraduateWork.Tests.APITests
{
    [AllureSuite("Suite: API Tests")]
    public class AttachmentTests : BaseApiTest
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [Test]
        [Category("NFE API Tests")]
        public void GetAllAttachmentsTest()
        {
            var attachments = AttachmentService.GetAttachments().Result;
            Assert.That(attachments.Status, Is.True);
        }

        [Test]
        [Category("NFE API Tests")]
        public void GetAttachmentByHashTest() 
        {
            // Загрузка JSON из файла
            string attachJson = File.ReadAllText(@"Resources/getAttach.json");

            // Создем экземпляр объекта из JSON
            var attachObj = JsonConvert.DeserializeObject<AttachmentResult>(attachJson);
            _logger.Info(attachObj.ToString);

            // Берем хэш из json-файла attachmentByHash.json
            string hash = attachObj.Result.Hash;

            // Отправляем в запросе этот хэш из файла attachmentByHash.json
            var attachment = AttachmentService.GetAttachmentByHash(hash).Result;
            _logger.Info(attachment);

            Assert.Multiple(() =>
            {
                Assert.That(attachment.Status);
                Assert.That(attachment.Result.Hash, Is.EqualTo(hash));
                Assert.That(attachment.Result.File, Is.EqualTo(attachObj.Result.File));
                Assert.That(attachment.Result.Size, Is.EqualTo(attachObj.Result.Size));
            });
        }

        [Test]
        [Category("NFE API Tests")]
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
        [Category("AFE API Tests")]
        public void GetAttachmentByHashNegativeTest()
        {
            string hash = "1289";
            var attachment = AttachmentService.GetAttachmentByHash(hash).Result;

            Assert.That(attachment.Status, Is.False);
            Assert.That(attachment.ErrorMessage, Is.EqualTo("Attachment not found"));
        }
    }
}
