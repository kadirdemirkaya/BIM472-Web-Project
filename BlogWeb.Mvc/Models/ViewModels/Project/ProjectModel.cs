using BlogWeb.Mvc.Entities;
using BlogWeb.Mvc.Models.Enums;
using BlogWeb.Mvc.Models.ViewModels.Article;

namespace BlogWeb.Mvc.Models.ViewModels.Project
{
    public class ProjectModel
    {
        public Guid Id { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public ProjectStatus ProjectStatus { get; set; } = ProjectStatus.Completed;

        public ProjectDetailModel ProjectDetail { get; set; }

        public ProjectModel()
        {

        }

        public ProjectModel ProjectMapper(Guid id, string topic, string description, string imagePath, ProjectStatus projectStatus)
        {
            Id = id;
            Topic = topic;
            Description = description;
            ImagePath = imagePath;
            ProjectStatus = projectStatus;
            return this;
        }

        public ProjectModel ProjectMapper(Guid id, string topic, string description, string imagePath, ProjectStatus projectStatus, ProjectDetail projectDetail)
        {
            Id = id;
            Topic = topic;
            Description = description;
            ImagePath = imagePath;
            ProjectStatus = projectStatus;
            ProjectDetail = new ProjectDetailModel();
            ProjectDetail.Description = projectDetail.Description;
            ProjectDetail.Goals = projectDetail.Goals;
            ProjectDetail.ImagePath = projectDetail.ImagePath;
            ProjectDetail.Links = projectDetail.Links;
            ProjectDetail.TechnologiesUsed = projectDetail.TechnologiesUsed;
            ProjectDetail.Topic = projectDetail.Topic;
            return this;
        }
    }
}
