using BlogWeb.Mvc.Models.ViewModels.Project;
using MediatR;

namespace BlogWeb.Mvc.Features.Queries.Project.GetAllProject
{
    public record GetAllProjectQueryRequest (
        
    ) : IRequest<List<ProjectModel>>;
}
