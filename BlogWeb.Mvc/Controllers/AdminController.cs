using BlogWeb.Mvc.Features.Commands.Projects.DeleteProject;
using BlogWeb.Mvc.Features.Queries.Article.GetAllArticles;
using BlogWeb.Mvc.Features.Queries.Article.GetArticlesByCategory;
using BlogWeb.Mvc.Features.Queries.Project.GetAllProject;
using BlogWeb.Mvc.Models.Enums;
using BlogWeb.Mvc.Models.ViewModels.Article;
using BlogWeb.Mvc.Models.ViewModels.Project;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Mvc.Controllers
{
    public class AdminController(IMediator _mediator) : BaseController
    {
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index(string? category = null)
        {
            GetAllProjectQueryRequest getAllProjectQueryRequest = new();
            List<ProjectModel> projectModels = await _mediator.Send(getAllProjectQueryRequest);

            return View(projectModels);
        }

        [HttpPost]
        [Route("DeleteProject")]
        public async Task<IActionResult> DeleteProject(Guid projectId)
        {
            DeleteProjectCommandRequest deleteProjectCommandRequest = new(projectId);
            bool response = await _mediator.Send(deleteProjectCommandRequest);

            return RedirectToAction("Index");
        }
    }
}
