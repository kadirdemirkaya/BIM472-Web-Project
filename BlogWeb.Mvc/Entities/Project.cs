using BlogWeb.Mvc.Entities.Base;
using BlogWeb.Mvc.Models.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BlogWeb.Mvc.Entities
{
    public class Project : BaseEntity
    {
        public string Topic { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public ProjectStatus ProjectStatus { get; set; } = ProjectStatus.Completed;

        public Guid ProjectDetailId { get; set; }
        public ProjectDetail ProjectDetail { get; set; }


        public Project()
        {

        }

        public Project(string topic, string description, string imagePath, ProjectStatus projectStatus, ProjectDetail projecttDetail)
        {
            AssignGuidToId();
            Topic = topic;
            Description = description;
            ImagePath = imagePath;
            ProjectStatus = projectStatus;
            ProjectDetail = projecttDetail;
        }

        public Project(Guid id, string topic, string description, string imagePath, ProjectStatus projectStatus, ProjectDetail projecttDetail)
        {
            SetId(id);
            Topic = topic;
            Description = description;
            ImagePath = imagePath;
            ProjectStatus = projectStatus;
            ProjectDetail = projecttDetail;
        }

        public static Project Create(string topic, string description, string imagePath, ProjectStatus projectStatus, ProjectDetail projecttDetail)
          => new(topic, description, imagePath, projectStatus, projecttDetail);

        public static Project Create(Guid id, string topic, string description, string imagePath, ProjectStatus projectStatus, ProjectDetail projecttDetail)
          => new(id, topic, description, imagePath, projectStatus, projecttDetail);

        //public void AddProjectDetails(string topic, string goals, string description, string imagePath, string links, string technologiesUsed, Guid projectId)
        //{
        //    ProjectDetails.Add(ProjectDetail.Create(topic, goals, description, imagePath, links, technologiesUsed, projectId));
        //}

        //public void AddProjectDetails(List<ProjectDetail> projectDetails)
        //{
        //    foreach (var projectDetail in projectDetails)
        //    {
        //        ProjectDetails.Add(ProjectDetail.Create(projectDetail.Topic, projectDetail.Goals, projectDetail.Description, projectDetail.ImagePath, projectDetail.Links, projectDetail.TechnologiesUsed, projectDetail.ProjectId));
        //    }
        //}
    }
}
