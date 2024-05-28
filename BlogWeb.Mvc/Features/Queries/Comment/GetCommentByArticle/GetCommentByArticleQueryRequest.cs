using BlogWeb.Mvc.Models.ViewModels.Comments;
using MediatR;

namespace BlogWeb.Mvc.Features.Queries.Comment.GetCommentByArticle
{
    public record GetCommentByArticleQueryRequest (
        Guid articleId
    ) : IRequest<List<CommentViewModel>>;
}
