using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiRoutes.Core.Models;

namespace WebApiRoutes.Core.Identity
{
    public interface IAuthManager
    {
        ResponseData SignIn(string userName, string passWord);

        ResponseData Register(JObject data);
    }
}