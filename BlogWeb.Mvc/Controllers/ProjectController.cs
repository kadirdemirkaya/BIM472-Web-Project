using BlogWeb.Mvc.Features.Queries.Project.GetAllProject;
using BlogWeb.Mvc.Features.Queries.Project.GetProjectDetail;
using BlogWeb.Mvc.Models.ViewModels.Project;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Mvc.Controllers
{
    [AllowAnonymous]
    public class ProjectController(IMediator _mediator) : BaseController
    {
        [HttpGet]
        [Route("GetAllProject")]
        public async Task<IActionResult> GetAllProject()
        {
            GetAllProjectQueryRequest getAllProjectQueryRequest = new();
            List<ProjectModel> projectModels = await _mediator.Send(getAllProjectQueryRequest);

            return View(projectModels);
        }

        [HttpGet]
        [Route("GetProjectDetail")]
        public async Task<IActionResult> GetProjectDetail(Guid projectId)
        {
            GetProjectDetailRequest getProjectDetailRequest = new(projectId);
            ProjectModel project = await _mediator.Send(getProjectDetailRequest);

            return View(project);
        }
    }
}
