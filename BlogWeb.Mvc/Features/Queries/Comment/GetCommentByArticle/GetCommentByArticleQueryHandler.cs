using BlogWeb.Mvc.Abstractions;
using BlogWeb.Mvc.Entities;
using BlogWeb.Mvc.Models.ViewModels.Comments;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BlogWeb.Mvc.Features.Queries.Comment.GetCommentByArticle
{
    public class GetCommentByArticleQueryHandler(IRepository<Entities.Comment> _commentRepository, UserManager<User> _userManager) : IRequestHandler<GetCommentByArticleQueryRequest, List<CommentViewModel>>
    {
        public async Task<List<CommentViewModel>> Handle(GetCommentByArticleQueryRequest request, CancellationToken cancellationToken)
        {
            List<Entities.Comment> comments = await _commentRepository.GetAllAsync(c => c.ArticleId == request.articleId);
            List<CommentViewModel> commentViewModels = new();
            if (comments.Count() == 0)
            {
                commentViewModels.Add(new() { ArticleId = request.articleId });
                return commentViewModels;
            }
            foreach (var comment in comments)
            {
                User user = await _userManager.FindByIdAsync(comment.UserId.ToString());
                commentViewModels.Add(new CommentViewModel().CommentMapper(comment.CommentText, user.UserName, request.articleId, comment.CreatedAt));
            }
            commentViewModels = commentViewModels.OrderBy(c => c.CreatedAt).ToList();
            return commentViewModels;
        }
    }
}
