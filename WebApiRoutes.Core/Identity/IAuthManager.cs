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
        ResponseUser SignIn(string userName, string passWord);

        ResponseUser Register(JObject data);
    }
}