using MediatR;

namespace BlogWeb.Mvc.Features.Commands.Projects.DeleteProject
{
    public record DeleteProjectCommandRequest(
        Guid projectId
    ) : IRequest<bool>;
}
