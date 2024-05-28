using BlogWeb.Mvc.Abstractions;
using BlogWeb.Mvc.Models.ViewModels.Project;
using MediatR;

namespace BlogWeb.Mvc.Features.Queries.Project.GetProjectDetail
{
    public class GetProjectDetailHandler(IRepository<Entities.Project> _projectRepository) : IRequestHandler<GetProjectDetailRequest, ProjectModel>
    {
        public async Task<ProjectModel> Handle(GetProjectDetailRequest request, CancellationToken cancellationToken)
        {
            Entities.Project project = await _projectRepository.GetAsync(p => p.Id == request.projectId, false, p => p.ProjectDetail);

            ProjectModel projectModel = new ProjectModel().ProjectMapper(project.Id, project.Topic, project.Description, project.ImagePath, project.ProjectStatus, project.ProjectDetail);

            return projectModel;
        }
    }
}
