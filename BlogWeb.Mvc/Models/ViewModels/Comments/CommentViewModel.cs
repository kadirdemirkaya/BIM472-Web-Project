using BlogWeb.Mvc.Entities;

namespace BlogWeb.Mvc.Models.ViewModels.Comments
{
    public class CommentViewModel
    {
        public string? CommentText { get; set; }
        public string? UserName { get; set; }
        public Guid ArticleId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public CommentViewModel()
        {

        }

        public CommentViewModel(string commentText, string userName, Guid articleId, DateTime createdAt)
        {
            CommentText = commentText;
            UserName = userName;
            ArticleId = articleId;
            CreatedAt = createdAt;
        }

        public CommentViewModel CommentMapper(string commentText, string userName, Guid articleId, DateTime createdAt)
        {
            CommentText = commentText;
            UserName = userName;
            ArticleId = articleId;
            CreatedAt = createdAt;
            return this;
        }
    }
}
