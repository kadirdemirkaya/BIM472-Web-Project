using BlogWeb.Mvc.Models.ViewModels.User;
using MediatR;

namespace BlogWeb.Mvc.Features.Queries.Auth.About
{
    public record AboutQueryRequest(

    ) : IRequest<List<UserClaimModel>>;
}
