using GraduateWork.Models;

namespace GraduateWork.Services
{
    public interface IAttachmentService
    {
        public Task<Attachments> GetAttachments();
        public Task<AttachmentResult> GetAttachmentByHash(string hash);
        public Task<UploadAttachment> UploadAttachment(string path);
    }
}
