using BlogWeb.Mvc.Models.ViewModels.Project;
using MediatR;

namespace BlogWeb.Mvc.Features.Queries.Project.GetProjectDetail
{
    public record GetProjectDetailRequest(
        Guid projectId
    ) : IRequest<ProjectModel>;
}
