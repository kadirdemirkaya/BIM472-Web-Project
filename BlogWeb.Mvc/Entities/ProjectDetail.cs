using BlogWeb.Mvc.Entities.Base;

namespace BlogWeb.Mvc.Entities
{
    public class ProjectDetail : BaseEntity
    {
        public string Topic { get; set; }
        public string Goals { get; set; }
        public string Description { get; set; }
        public string? ImagePath { get; set; }
        public string Links { get; set; }
        public string TechnologiesUsed { get; set; }

        public Project Project { get; set; }

        public ProjectDetail()
        {

        }

        public ProjectDetail(string topic, string goals, string description, string imagePath, string links, string technologiesUsed)
        {
            AssignGuidToId();
            Topic = topic;
            Description = description;
            ImagePath = imagePath;
            Goals = goals;
            Links = links;
            TechnologiesUsed = technologiesUsed;
        }

        public ProjectDetail(Guid id, string topic, string goals, string description, string imagePath, string links, string technologiesUsed)
        {
            SetId(id);
            Topic = topic;
            Description = description;
            ImagePath = imagePath;
            Goals = goals;
            Links = links;
            TechnologiesUsed = technologiesUsed;
        }

        public static ProjectDetail Create(string topic, string goals, string description, string imagePath, string links, string technologiesUsed)
            => new(topic, goals, description, imagePath, links, technologiesUsed);

        public static ProjectDetail Create(Guid id, string topic, string goals, string description, string imagePath, string links, string technologiesUsed)
          => new(id, topic, goals, description, imagePath, links, technologiesUsed);
    }
}
