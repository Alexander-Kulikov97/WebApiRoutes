using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiRoutes.App_Code;

namespace WebApiRoutes.Controllers
{
    public class BaseController : Controller
    {
        protected virtual JsonResult Json<T>(T data, int statusCode)
        {
            try
            {
                BaseResponse<T> baseResponse = new BaseResponse<T>
                {
                    Data = data
                };

                Response.StatusCode = statusCode;

                return base.Json(baseResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected virtual IActionResult ExceptionResult(Exception ex)
        {
            throw new NotImplementedException();
        }

    }
}
