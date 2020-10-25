using System;
using Microsoft.AspNetCore.Mvc;
using WebApiRoutes.App_Code;

namespace WebApiRoutes.Controllers
{
    public class BaseController : Controller
    {
        protected virtual IActionResult Json<T>(T data, string statusCode = "")
        {
            try
            {
                BaseResponse<T> baseResponse = new BaseResponse<T>
                {
                    Status = string.IsNullOrEmpty(statusCode) ? App_Code.StatusCode.SUCCESS : statusCode,
                    Data = data
                };

                if (baseResponse.Status == App_Code.StatusCode.SUCCESS)
                {
                    Response.StatusCode = 200;
                }
                else if (baseResponse.Status == App_Code.StatusCode.NON_HANDLED_ERROR)
                {
                    Response.StatusCode = 500;
                }
                else
                {
                    Response.StatusCode = 400;
                }

                JsonResult a = base.Json(baseResponse);
                return a;
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
