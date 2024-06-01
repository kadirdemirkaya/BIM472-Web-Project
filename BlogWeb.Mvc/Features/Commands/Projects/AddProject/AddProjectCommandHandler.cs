using BlogWeb.Mvc.Abstractions;
using BlogWeb.Mvc.Entities;
using MediatR;

namespace BlogWeb.Mvc.Features.Commands.Projects.AddProject
{
    public class AddProjectCommandHandler(IRepository<Project> _projectRepository) : IRequestHandler<AddProjectCommandRequest, bool>
    {
        public async Task<bool> Handle(AddProjectCommandRequest request, CancellationToken cancellationToken)
        {
            ProjectDetail projectDetail = ProjectDetail.Create(request.AddProjectViewModel.Topic, request.AddProjectViewModel.Goals, request.AddProjectViewModel.LongDescription, "", request.AddProjectViewModel.Links, request.AddProjectViewModel.TechnologiesUsed);

            Project project = Project.Create(request.AddProjectViewModel.Topic, request.AddProjectViewModel.ShortDescription, request.AddProjectViewModel.ImagePath, request.AddProjectViewModel.ProjectStatus, projectDetail);

            if (await _projectRepository.AddAsync(project))
                return await _projectRepository.SaveChangesAsync();
            return false;
        }
    }
}
