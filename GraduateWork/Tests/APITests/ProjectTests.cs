using Allure.NUnit.Attributes;
using GraduateWork.Services;
using TestRaGraduateWorkilComplexApi.Tests;

namespace GraduateWork.Tests.APITests
{
    [AllureSuite("Suite: API Tests")]
    public class ProjectTests : BaseApiTest
    {
        [Test]
        [Category("NFE API Tests")]
        public void GetAllProjectsTest()
        {
            var projects = ProjectService.GetProjects().Result;
            Assert.That(projects.Status, Is.True);
            Assert.That(projects.Result.Count, Is.EqualTo(1));
        }

        [Test]
        [Category("AFE API Tests")]
        public void GetProjectByCodeNegativeTest()
        {
            string code = "59289";
            var project = ProjectService.GetProjectByCode(code).Result;

            Assert.That(project.Status, Is.False);
            Assert.That(project.ErrorMessage, Is.EqualTo("Project not found"));
        }
    }
}
