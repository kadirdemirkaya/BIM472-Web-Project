using BlogWeb.Mvc.Models.Enums;
using BlogWeb.Mvc.Models.ViewModels.Article;
using MediatR;

namespace BlogWeb.Mvc.Features.Queries.Article.GetArticlesByCategory
{
    public record GetArticlesByCategoryQueryRequest(
        CategoryName CategoryName
    ) : IRequest<List<ArticleModel>>;
}
