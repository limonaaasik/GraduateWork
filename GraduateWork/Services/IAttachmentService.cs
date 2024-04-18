using GraduateWork.Models;

namespace GraduateWork.Services
{
    public interface IAttachmentService
    {
        public Task<Attachments> GetAttachments();
        public Task<Attachment> GetAttachmentByHash(string hash);
    }
}
