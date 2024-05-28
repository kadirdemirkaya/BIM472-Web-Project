using BlogWeb.Mvc.Models.ViewModels;
using MediatR;

namespace BlogWeb.Mvc.Features.Commands.Auth.Register
{
    public record RegisterCommandRequest(
          RegisterViewModel RegisterViewModel
      ) : IRequest<RegisterCommandResponse>;
}
