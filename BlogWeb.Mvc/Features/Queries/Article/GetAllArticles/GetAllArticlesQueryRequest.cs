using BlogWeb.Mvc.Models.ViewModels.Article;
using MediatR;

namespace BlogWeb.Mvc.Features.Queries.Article.GetAllArticles
{
    public record GetAllArticlesQueryRequest(
    ) : IRequest<List<ArticleModel>>;
}
