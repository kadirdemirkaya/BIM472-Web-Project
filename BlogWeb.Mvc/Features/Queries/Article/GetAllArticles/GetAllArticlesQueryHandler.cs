using BlogWeb.Mvc.Abstractions;
using BlogWeb.Mvc.Models.ViewModels.Article;
using MediatR;

namespace BlogWeb.Mvc.Features.Queries.Article.GetAllArticles
{
    public class GetAllArticlesQueryHandler(IRepository<Entities.Article> _articleRepository) : IRequestHandler<GetAllArticlesQueryRequest, List<ArticleModel>>
    {
        public async Task<List<ArticleModel>> Handle(GetAllArticlesQueryRequest request, CancellationToken cancellationToken)
        {
            List<Entities.Article> articles = await _articleRepository.GetAllAsync();

            List<ArticleModel> articleModels = new();
            foreach (var article in articles)
                articleModels.Add(new ArticleModel().ArticleMapper(article.Id, article.Title, article.Description, article.ImagePath, article.CreatedAt));

            //return new(articleModels);          
            return articleModels;
        }
    }
}
