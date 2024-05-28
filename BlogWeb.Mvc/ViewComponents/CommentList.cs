using BlogWeb.Mvc.Features.Queries.Comment.GetCommentByArticle;
using BlogWeb.Mvc.Models.ViewModels.Comments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Mvc.ViewComponents
{
    public class CommentList(IMediator _mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Guid articleId)
        {
            GetCommentByArticleQueryRequest getCommentByArticleQueryRequest = new(articleId);
            List<CommentViewModel> commentViewModels = await _mediator.Send(getCommentByArticleQueryRequest);
            return View(commentViewModels);
        }
    }
}
