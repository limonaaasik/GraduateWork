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

        public Task<Attachment> GetAttachmentByHash(string hash)
        {
            var request = new RestRequest("/v1/attachment/{hash}")
                .AddUrlSegment("hash", hash);
            return _client.ExecuteAsync<Attachment>(request);
        }

        public Task<Attachments> GetAttachments()
        {
            var request = new RestRequest("/v1/attachment");

            return _client.ExecuteAsync<Attachments>(request);
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
