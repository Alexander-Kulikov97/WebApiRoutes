using Newtonsoft.Json.Linq;
using StoregeServices.Contracts.Models;
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
        AuthUser SignIn(string userName, string passWord);

        AuthUser Register(JObject data);

        List<UserModel> GetAllUsers();
    }
}