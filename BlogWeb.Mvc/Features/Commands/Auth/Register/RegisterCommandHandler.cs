using BlogWeb.Mvc.Abstractions;
using BlogWeb.Mvc.Models.Response;
using MediatR;

namespace BlogWeb.Mvc.Features.Commands.Auth.Register
{
    public class RegisterCommandHandler(IUserServive userServive) : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
    {
        private readonly IUserServive _userServive = userServive;

        public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            UserResponseModel userResponseModel = await _userServive.UserRegisterAsync(request.RegisterViewModel);
            return new(userResponseModel);
        }
    }
}
