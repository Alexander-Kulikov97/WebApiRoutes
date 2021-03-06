﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiRoutes.Models.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Newtonsoft.Json.Linq;
using WebApiRoutes.Core.Identity;

namespace WebApiRoutes.Controllers
{
    [Produces("application/json")]
    [Route("api/account")]
    [ApiController]
    public class AccauntController : BaseController
    {
        private readonly IAuthManager _authManager;

        public AccauntController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "Email": "",
        ///         "Password": ""
        ///     }
        /// </remarks>
        /// <param name="data"></param>
        /// <response code="200"></response>
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] JObject data)
        {
            try
            {
                var model = data.ToObject<LoginModel>();
                if (model != null)
                {
                    var authUser = _authManager.SignIn(model.Email, model.Password);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(authUser.ClaimsIdentity));
                    return Json(authUser.data);
                }
                return Json("Неверные данные", "ERROR");
            }
            catch (Exception ex)
            {
                return Json(ex.StackTrace);
            }
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "FirstName": "",
        ///         "LastName": "",
        ///         "MiddleName": "",
        ///         "Email": "",
        ///         "Password": "",
        ///         "Login": ""
        ///     }
        /// </remarks>
        /// <param name="data"></param>
        /// <response code="200"></response>
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] JObject data)
        {
            try 
            {
                if (data != null)
                {
                    var authUser = _authManager.Register(data);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(authUser.ClaimsIdentity));
                    return Json(authUser.data);
                }
                return Json("Неверные данные", "ERROR");
            }
            catch (Exception ex)
            {
                return Json(ex.StackTrace);
            }
        }

        /// <summary>
        /// Выход
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Todo
        /// </remarks>
        /// <param name="data"></param>
        /// <response code="200"></response>
        [Route("logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Json("Signout success");
        }
    }
}
