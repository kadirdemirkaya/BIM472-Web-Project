using BlogWeb.Mvc.Models.Response;

namespace BlogWeb.Mvc.Features.Commands.Auth.Login
{
    public record LoginCommandResponse(
           UserResponseModel UserResponseModel
       );
}
