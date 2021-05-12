using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiRoutes.Models.Authentication;
using Newtonsoft.Json.Linq;
using WebApiRoutes.Core.Identity;
using Microsoft.AspNetCore.Authorization;

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
                    
                    return Json(authUser, 200);
                }
                return Json("Неверные данные", 400);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, 500);
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
                    return Json(authUser, 200);
                }
                return Json("Неверные данные", 400);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, 500);
            }
        }

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200"></response>
        [Authorize(Roles = "admin")]
        [Route("getusers")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Json(_authManager.GetAllUsers());
        }

        /// <summary>
        /// Установить онлайн
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200"></response>
        //[Authorize(Roles = "admin")]
        [Route("{userId}/setonline/{isOnline}")]
        [HttpGet]
        public async Task<IActionResult> SetOnline(int userId, bool isOnline)
        {
            _authManager.SetOnline(userId, isOnline);
            return Json("online установлен", 200);
        }

        /// <summary>
        /// Получить статус онлайна
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200"></response>
        //[Authorize(Roles = "admin")]
        [Route("IsOnline/{userId}")]
        [HttpGet]
        public async Task<IActionResult> IsOnline(int userId)
        {
            return Json(_authManager.IsOnline(userId));
        }

        ///// <summary>
        ///// Выход
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /Todo
        ///// </remarks>
        ///// <param name="data"></param>
        ///// <response code="200"></response>
        //[Route("logout")]
        //[HttpGet]
        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return Json("Signout success");
        //}
    }
}
