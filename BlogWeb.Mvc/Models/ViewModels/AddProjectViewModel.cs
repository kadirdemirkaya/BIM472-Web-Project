using BlogWeb.Mvc.Models.Enums;

namespace BlogWeb.Mvc.Models.ViewModels
{
    public class AddProjectViewModel
    {
        public string Topic { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImagePath { get; set; }
        public ProjectStatus ProjectStatus { get; set; } = ProjectStatus.Completed;
        public string Goals { get; set; }
        public string Links { get; set; }
        public string TechnologiesUsed { get; set; }
    }
}
