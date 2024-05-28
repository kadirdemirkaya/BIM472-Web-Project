namespace BlogWeb.Mvc.Models.ViewModels.Project
{
    public class ProjectDetailModel
    {
        public string Topic { get; set; }
        public string Goals { get; set; }
        public string Description { get; set; }
        public string? ImagePath { get; set; }
        public string Links { get; set; }
        public string TechnologiesUsed { get; set; }

        public ProjectDetailModel()
        {

        }
        public ProjectDetailModel(string topic, string goals, string description, string? imagePath, string links, string technologiesUsed)
        {
            Topic = topic;
            Goals = goals;
            Description = description;
            ImagePath = imagePath;
            Links = links;
            TechnologiesUsed = technologiesUsed;
        }


    }
}
