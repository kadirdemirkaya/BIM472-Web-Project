using BlogWeb.Mvc.Abstractions;
using MediatR;

namespace BlogWeb.Mvc.Features.Commands.Comment.CreateComment
{
    public class CreateCommentCommandHandler(IRepository<Entities.Comment> _commentRepository) : IRequestHandler<CreateCommentCommandRequest, bool>
    {
        public async Task<bool> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            bool response = await _commentRepository.AddAsync(Entities.Comment.Create(request.CreateCommentViewModel.Comment, request.userId, request.CreateCommentViewModel.ArticleId));

            if (!response)
                return false;

            return await _commentRepository.SaveChangesAsync() is true ? true : false;
        }
    }
}
