namespace BlogWeb.Mvc.Models.ViewModels.Article
{
    public class ArticleDetailModel
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public Guid ArticleId { get; set; }
        public DateTime CreatedAt { get; set; }

        public ArticleDetailModel(Guid id, string key, string value, Guid articleId, DateTime createdAt)
        {
            Id = id;
            Key = key;
            Value = value;
            ArticleId = articleId;
            CreatedAt = createdAt;
        }
    }
}
