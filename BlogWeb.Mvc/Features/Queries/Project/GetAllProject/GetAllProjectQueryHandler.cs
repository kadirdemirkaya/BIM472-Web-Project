using BlogWeb.Mvc.Abstractions;
using BlogWeb.Mvc.Models.ViewModels.Project;
using MediatR;

namespace BlogWeb.Mvc.Features.Queries.Project.GetAllProject
{
    public class GetAllProjectQueryHandler(IRepository<Entities.Project> _projectRepository) : IRequestHandler<GetAllProjectQueryRequest, List<ProjectModel>>
    {
        public async Task<List<ProjectModel>> Handle(GetAllProjectQueryRequest request, CancellationToken cancellationToken)
        {
            List<Entities.Project> projects = await _projectRepository.GetAllAsync(p => p.IsActive == true);
            List<ProjectModel> projectModels = new();

            foreach (var project in projects)
                projectModels.Add(new ProjectModel().ProjectMapper(project.Id, project.Topic, project.Description, project.ImagePath, project.ProjectStatus));

            return new(projectModels);
        }
    }
}
