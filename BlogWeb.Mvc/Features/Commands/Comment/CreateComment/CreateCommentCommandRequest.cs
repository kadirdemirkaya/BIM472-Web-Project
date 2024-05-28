using BlogWeb.Mvc.Models.ViewModels.Comments;
using MediatR;

namespace BlogWeb.Mvc.Features.Commands.Comment.CreateComment
{
    public record CreateCommentCommandRequest(
        Guid userId,
        CreateCommentViewModel CreateCommentViewModel
    ) : IRequest<bool>;
}
