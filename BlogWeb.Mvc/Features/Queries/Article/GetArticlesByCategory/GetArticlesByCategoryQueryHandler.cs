using BlogWeb.Mvc.Abstractions;
using BlogWeb.Mvc.Entities;
using BlogWeb.Mvc.Models.ViewModels.Article;
using MediatR;

namespace BlogWeb.Mvc.Features.Queries.Article.GetArticlesByCategory
{
    public class GetArticlesByCategoryQueryHandler(IRepository<Entities.Article> _articleRepository, IRepository<Entities.Category> _categoryRepository) : IRequestHandler<GetArticlesByCategoryQueryRequest, List<ArticleModel>>
    {
        public async Task<List<ArticleModel>> Handle(GetArticlesByCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            Category? category = await _categoryRepository.GetAsync(c => c.CategoryName == request.CategoryName);
            List<Entities.Article> articles = await _articleRepository.GetAllAsync(a => a.CategoryId == category.Id);

            List<ArticleModel> articleModels = new();
            foreach (var article in articles)
                articleModels.Add(new ArticleModel().ArticleMapper(article.Id, article.Title, article.Description, article.ImagePath, article.CreatedAt));

            return articleModels;
        }
    }
}
