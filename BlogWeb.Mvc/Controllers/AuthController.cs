﻿using BlogWeb.Mvc.Abstractions;
using BlogWeb.Mvc.Concretes;
using BlogWeb.Mvc.Constants;
using BlogWeb.Mvc.Entities;
using BlogWeb.Mvc.Features.Commands.Auth.Login;
using BlogWeb.Mvc.Features.Commands.Auth.Register;
using BlogWeb.Mvc.Features.Queries.Auth.About;
using BlogWeb.Mvc.Models.ViewModels;
using BlogWeb.Mvc.Models.ViewModels.User;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;

namespace BlogWeb.Mvc.Controllers
{
    [AllowAnonymous]
    public class AuthController(IUserServive _userServive, UserManager<User> _userManager, SignInManager<User> _signInManager, IMediator _mediatr, IToastNotification _toastNotification) : BaseController
    {
        [HttpGet]
        [Route("Register")]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        /// <summary>
        /// kayıt yapılan uçnokta 
        /// </summary>
        /// <param name="registerViewModel"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
                return View("Model properties is not valid");

            RegisterCommandRequest registerCommandRequest = new(registerViewModel);
            RegisterCommandResponse registerCommandResponse = await _mediatr.Send(registerCommandRequest);

            if (registerCommandResponse.UserResponseModel.IsSuccess is true)
                _toastNotification.AddSuccessToastMessage("Kayıt işlemi başarılı");
            else
                _toastNotification.AddErrorToastMessage("Kayıt işlemi başarısız");

            if (!string.IsNullOrEmpty(returnUrl))
                return LocalRedirect(returnUrl);

            return registerCommandResponse.UserResponseModel.IsSuccess is false ? View() : View("Login");
        }



        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        /// <summary>
        /// giriş yapılan uç nokta
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl = null)
        {

            if (!ModelState.IsValid)
                return View("Model properties is not valid");

            LoginCommandRequest loginCommandRequest = new(loginViewModel);
            LoginCommandResponse loginCommandResponse = await _mediatr.Send(loginCommandRequest);

            if (loginCommandResponse.UserResponseModel.IsSuccess is false)
                return View();

            List<Claim> claims = new();
            if (loginViewModel.Email != "kadir@gmail.com")
            {
                claims = new List<Claim>
                {
                            new Claim(ClaimTypes.Name, loginViewModel.Email),
                            new Claim(ClaimTypes.Email, loginViewModel.Email),
                            new Claim(ClaimTypes.Role, Constant.Role.User),
                            new Claim("Email",loginViewModel.Email),
                };
            }
            else
            {
                claims = new List<Claim>
                {
                            new Claim(ClaimTypes.Name, loginViewModel.Email),
                            new Claim(ClaimTypes.Email, loginViewModel.Email),
                            new Claim(ClaimTypes.Role, Constant.Role.Admin),
                            new Claim("Email",loginViewModel.Email),
                };
            }
            

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            User user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

            var signInResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, isPersistent: false, lockoutOnFailure: false);

            await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

            if (loginCommandResponse.UserResponseModel.IsSuccess is true)
                _toastNotification.AddSuccessToastMessage("Giriş işlemi başarılı");
            else
                _toastNotification.AddSuccessToastMessage("Giriş işlemi başarısız");

            if (!string.IsNullOrEmpty(returnUrl))
                return LocalRedirect(returnUrl);

            return loginCommandResponse.UserResponseModel.IsSuccess is false ? View() : RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// çıkış yapılan uçnokta
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            var email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync();

            if (email is null)
                return View("Login");

            _toastNotification.AddSuccessToastMessage("Çıkış işlemi başarılı");

            return View("Login");
        }

        /// <summary>
        /// hakkında tablosundan claims bilgilerini getirir
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("About")]
        public async Task<IActionResult> About()
        {
            AboutQueryRequest aboutQueryRequest = new();
            List<UserClaimModel> userClaimModels = await _mediatr.Send(aboutQueryRequest);

            return View(userClaimModels);
        }
    }
}
