using BlogWeb.Mvc.Entities.Base;

namespace BlogWeb.Mvc.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }


        public Guid CategoryId { get; set; }
        public Category Category { get; set; }


        public List<Comment> Comments { get; set; }
        public List<ArticleDetail> ArticleDetails { get; set; } = new();


        public Article()
        {

        }

        public Article(string title, string description, string imagePath, Guid categoryId)
        {
            AssignGuidToId();
            Title = title;
            Description = description;
            ImagePath = imagePath;
            CategoryId = categoryId;
        }
        public Article(Guid id, string title, string description, string imagePath, Guid categoryId)
        {
            SetId(id);
            Title = title;
            Description = description;
            ImagePath = imagePath;
            CategoryId = categoryId;
        }

        public static Article Create(string title, string description, string imagePath, Guid categoryId)
            => new(title, description, imagePath,categoryId);

        public static Article Create(Guid id, string title, string description, string imagePath, Guid categoryId)
          => new(id, title, description, imagePath,categoryId);

        public void AddArticleDetail(ArticleDetail articleDetails)
        {
            ArticleDetails.Add(articleDetails);
        }

        public void AddArticleDetail(List<ArticleDetail> articleDetails)
        {
            if (ArticleDetails == null)
                ArticleDetails = new List<ArticleDetail>();
            foreach (var articleDetail in articleDetails)
            {
                ArticleDetails.Add(articleDetail);
            }
        }
    }
}
