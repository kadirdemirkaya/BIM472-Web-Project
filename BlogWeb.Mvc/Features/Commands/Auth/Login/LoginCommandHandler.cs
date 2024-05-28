using BlogWeb.Mvc.Abstractions;
using BlogWeb.Mvc.Entities;
using BlogWeb.Mvc.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BlogWeb.Mvc.Features.Commands.Auth.Login
{
    public class LoginCommandHandler(IUserServive userServive, UserManager<User> _userManager, SignInManager<User> _signInManager) : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IUserServive _userServive = userServive;

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            UserResponseModel? userResponseModel = await _userServive.UserLoginAsync(request.LoginViewModel);

            return new(userResponseModel);
        }
    }
}
