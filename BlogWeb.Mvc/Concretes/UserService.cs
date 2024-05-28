using BlogWeb.Mvc.Abstractions;
using BlogWeb.Mvc.Constants;
using BlogWeb.Mvc.Entities;
using BlogWeb.Mvc.Models.Response;
using BlogWeb.Mvc.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace BlogWeb.Mvc.Concretes
{
    public class UserService(UserManager<User> _userManager) : IUserServive
    {
        public async Task<UserResponseModel> UserLoginAsync(LoginViewModel loginViewModel)
        {
            if (loginViewModel is null)
                throw new NullReferenceException($"{nameof(LoginViewModel)} is null !");

            User? user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if (user is null)
                return new()
                {
                    IsSuccess = false,
                    Errors = new string[] { "User Not found" }
                };

            bool result = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);

            if (!result)
                return new()
                {
                    IsSuccess = false,
                    Errors = new string[] { "Invalid user inputs" }
                };

            return new()
            {
                IsSuccess = true,
            };
        }

        public async Task<UserResponseModel> UserRegisterAsync(RegisterViewModel registerViewModel)
        {
            if (registerViewModel is null)
                throw new NullReferenceException($"{nameof(RegisterViewModel)} is null !");

            User user = User.Create(registerViewModel.Name, registerViewModel.Email, "0000000000");

            IdentityResult result = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (result.Succeeded)
            {
                IdentityResult? roleResult = await _userManager.AddToRoleAsync(user, Constant.Role.User);
                return roleResult.Succeeded is true ? new() { IsSuccess = true } : new() { IsSuccess = false };
            }
            else
            {
                string[] errorMessages = result.Errors.Select(e => e.Description).ToArray();
                return new()
                {
                    IsSuccess = false,
                    Errors = errorMessages
                };
            }
        }
    }
}
