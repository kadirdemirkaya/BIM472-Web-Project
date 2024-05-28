using BlogWeb.Mvc.Entities;

namespace BlogWeb.Mvc.Models.ViewModels.Article
{
    public class ArticleModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<ArticleDetailModel> ArticleDetailModel { get; set; } = new();

        public ArticleModel()
        {

        }

        public ArticleModel ArticleMapper(Guid id, string title, string description, string imagePath, DateTime createdAt)
        {
            Id = id;
            Title = title;
            Description = description;
            ImagePath = imagePath;
            CreatedAt = createdAt;
            return this;
        }

        public ArticleModel ArticleMapper(Guid id, string title, string description, string imagePath, DateTime createdAt, List<ArticleDetail> articleDetailModels)
        {
            Id = id;
            Title = title;
            Description = description;
            ImagePath = imagePath;
            CreatedAt = createdAt;
            foreach (var articleDetailModel in articleDetailModels)
            {
                ArticleDetailModel.Add(new(articleDetailModel.Id, articleDetailModel.Key, articleDetailModel.Value, articleDetailModel.ArticleId, articleDetailModel.CreatedAt));
            }
            return this;
        }
    }
}
