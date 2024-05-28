using BlogWeb.Mvc.Entities.Base;

namespace BlogWeb.Mvc.Entities
{
    public class ArticleDetail : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }


        public Guid ArticleId { get; set; }
        public Article Article { get; set; }


        public ArticleDetail()
        {

        }
        public ArticleDetail(string key, string value, Guid articleId)
        {
            AssignGuidToId();
            Key = key;
            Value = value;
            ArticleId = articleId;
        }
        public ArticleDetail(Guid id, string key, string value, Guid articleId)
        {
            SetId(id);
            Key = key;
            Value = value;
            ArticleId = articleId;
        }

        public static ArticleDetail Create(string key, string value, Guid articleId)
            => new(key, value, articleId);

        public static ArticleDetail Create(Guid id, string key, string value, Guid articleId)
            => new(id, key, value, articleId);
    }
}
