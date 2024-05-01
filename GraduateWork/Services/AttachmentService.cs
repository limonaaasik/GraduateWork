using GraduateWork.Models;
using RestSharp;
using GraduateWork.Clients;

namespace GraduateWork.Services
{
    public class AttachmentService : IAttachmentService, IDisposable
    {
        private readonly RestClientExtended _client;

        public AttachmentService(RestClientExtended client)
        {
            _client = client;
        }

        public Task<AttachmentResult> GetAttachmentByHash(string hash)
        {
            var request = new RestRequest("/v1/attachment/{hash}")
                .AddUrlSegment("hash", hash);
            return _client.ExecuteAsync<AttachmentResult>(request);
        }

        public Task<Attachments> GetAttachments()
        {
            var request = new RestRequest("/v1/attachment");

            return _client.ExecuteAsync<Attachments>(request);
        }
        
        public Task<UploadAttachment> UploadAttachment(string path)
        {
            var request = new RestRequest("/v1/attachment/{code}", Method.Post)
            .AddUrlSegment("code", "DEMO")
            .AddFile("file", path);

            return _client.ExecuteAsync<UploadAttachment>(request);
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
