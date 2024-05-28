using BlogWeb.Mvc.Models.Response;

namespace BlogWeb.Mvc.Features.Commands.Auth.Register
{
    public record RegisterCommandResponse(
      UserResponseModel UserResponseModel
  );
}
