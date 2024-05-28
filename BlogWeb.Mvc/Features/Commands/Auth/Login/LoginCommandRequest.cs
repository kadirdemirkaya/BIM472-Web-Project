using BlogWeb.Mvc.Models.ViewModels;
using MediatR;

namespace BlogWeb.Mvc.Features.Commands.Auth.Login
{
    public record LoginCommandRequest(
       LoginViewModel LoginViewModel
   ) : IRequest<LoginCommandResponse>;
}
