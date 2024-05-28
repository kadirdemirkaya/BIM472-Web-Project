using BlogWeb.Mvc.Abstractions;
using BlogWeb.Mvc.Entities;
using BlogWeb.Mvc.Models.ViewModels.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BlogWeb.Mvc.Features.Queries.Auth.About
{
    public class AboutQueryHandler(UserManager<User> _userManager, IRepository<UserClaim> _userClaimRepository) : IRequestHandler<AboutQueryRequest, List<UserClaimModel>>
    {
        public async Task<List<UserClaimModel>> Handle(AboutQueryRequest request, CancellationToken cancellationToken)
        {
            User? user = await _userManager.FindByIdAsync("292CD015-D34E-4A0B-84AF-F2D58105356B");

            List<UserClaim> userClaims = await _userClaimRepository.GetAllAsync(uc => uc.UserId == user.Id);

            List<UserClaimModel> userClaimModels = new UserClaimModel().UserClaimMapper(userClaims);

            return new(userClaimModels);
        }
    }
}
