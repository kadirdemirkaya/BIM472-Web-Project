using BlogWeb.Mvc.Concretes;
using BlogWeb.Mvc.Entities;
using BlogWeb.Mvc.Features.Commands.Comment.CreateComment;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogWeb.Mvc.Controllers
{
    public class CommentController(IMediator _mediator, UserManager<User> _userManager, NotificationService _notificationService) : BaseController
    {
        [HttpPost]
        [Route("AddCommentByArticle")]
        [ValidateAntiForgeryToken] // (Cross-Site Request Forgery) 
        public async Task<IActionResult> AddCommentByArticle(Guid articleId, string comment)
        {
            var userEmailClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            User user = await _userManager.FindByEmailAsync(userEmailClaim.Value);

            CreateCommentCommandRequest commentCommandRequest = new(user.Id, new() { ArticleId = articleId, Comment = comment });
            bool response = await _mediator.Send(commentCommandRequest);

            if (response is true)
                _notificationService.CreateSuccessfullyNotification("Yorum başarıyla eklendi");
            else
                _notificationService.CreateErrorNotification("Yorum eklenirken bir sorun oluştu");

            return RedirectToAction("GetAllArticleDetail", "Article", new { articleId = articleId });
        }
    }
}
