using GraduateWork.Models;
using RestSharp;
using GraduateWork.Clients;

namespace GraduateWork.Services
{
    public class ProjectService : IProjectService, IDisposable
    {
        private readonly RestClientExtended _client;

        public ProjectService(RestClientExtended client)
        {
            _client = client;
        }

        public Task<Projects> GetProjects()
        {
            var request = new RestRequest("/v1/project");

            return _client.ExecuteAsync<Projects>(request);
        }

        public Task<Projects> GetProjectByCode(string code)
        {
            var request = new RestRequest("/v1/project/{code}")
                .AddUrlSegment("code", code);
            return _client.ExecuteAsync<Projects>(request);
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
