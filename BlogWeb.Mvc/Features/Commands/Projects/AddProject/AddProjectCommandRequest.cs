using BlogWeb.Mvc.Models.ViewModels;
using MediatR;

namespace BlogWeb.Mvc.Features.Commands.Projects.AddProject
{
    public record AddProjectCommandRequest (
        AddProjectViewModel AddProjectViewModel
    ) : IRequest<bool>;
}
