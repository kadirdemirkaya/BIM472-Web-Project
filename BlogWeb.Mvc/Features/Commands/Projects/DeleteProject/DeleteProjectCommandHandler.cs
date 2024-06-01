using BlogWeb.Mvc.Abstractions;
using BlogWeb.Mvc.Entities;
using MediatR;

namespace BlogWeb.Mvc.Features.Commands.Projects.DeleteProject
{
    public class DeleteProjectCommandHandler(IRepository<Project> _projectRepository) : IRequestHandler<DeleteProjectCommandRequest, bool>
    {
        public async Task<bool> Handle(DeleteProjectCommandRequest request, CancellationToken cancellationToken)
        {
            Project? project = await _projectRepository.GetAsync(p => p.Id == request.projectId);
            project.SetActiveState(false);
            _projectRepository.Update(project);
            return await _projectRepository.SaveChangesAsync();
        }
    }
}
