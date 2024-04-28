using GraduateWork.Models;

namespace GraduateWork.Services
{
    public interface IProjectService
    {
        public Task<Projects> GetProjects();
        public Task<Projects> GetProjectByCode(string code);
    }
}
