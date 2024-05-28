using BlogWeb.Mvc.Models.Response;
using BlogWeb.Mvc.Models.ViewModels;

namespace BlogWeb.Mvc.Abstractions
{

    public interface IUserServive
    {
        Task<UserResponseModel> UserRegisterAsync(RegisterViewModel registerViewModel);

        Task<UserResponseModel> UserLoginAsync(LoginViewModel loginViewModel);
    }
}
