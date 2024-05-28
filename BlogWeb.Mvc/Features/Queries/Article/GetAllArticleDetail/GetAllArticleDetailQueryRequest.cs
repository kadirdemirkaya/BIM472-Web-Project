using BlogWeb.Mvc.Entities;
using BlogWeb.Mvc.Models.ViewModels.Article;
using MediatR;

namespace BlogWeb.Mvc.Features.Queries.Article.GetAllArticleDetail
{
    public record GetAllArticleDetailQueryRequest (
        Guid articleId
    ) : IRequest<ArticleModel>;
}
