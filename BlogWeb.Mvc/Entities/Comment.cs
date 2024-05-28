using BlogWeb.Mvc.Entities.Base;

namespace BlogWeb.Mvc.Entities
{
    public class Comment : BaseEntity
    {
        public string CommentText { get; set; }


        public Guid ArticleId { get; set; }
        public Article Article { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Comment()
        {

        }

        public Comment(string commentText, Guid userId, Guid articleId)
        {
            AssignGuidToId();
            CommentText = commentText;
            UserId = userId;
            ArticleId = articleId;
        }
        public Comment(Guid id, string commentText, Guid userId, Guid articleId)
        {
            SetId(id);
            CommentText = commentText;
            UserId = userId;
            ArticleId = articleId;
        }

        public static Comment Create(string commentText, Guid userId, Guid articleId)
            => new(commentText, userId, articleId);

        public static Comment Create(Guid id, string commentText, Guid userId, Guid articleId)
         => new(id, commentText, userId, articleId);
    }
}
