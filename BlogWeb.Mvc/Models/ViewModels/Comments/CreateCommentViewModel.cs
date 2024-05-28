namespace BlogWeb.Mvc.Models.ViewModels.Comments
{
    public class CreateCommentViewModel
    {
        public string Comment { get; set; }

        public Guid ArticleId { get; set; }
    }
}
