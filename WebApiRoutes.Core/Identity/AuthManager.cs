using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiRoutes.Data.Context;
using WebApiRoutes.Data.Repositories;
using System.Linq;
using WebApiRoutes.Core.Models;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace WebApiRoutes.Core.Identity
{
    public class AuthManager : IAuthManager
    {

        private readonly IRepository db;
        private readonly IHasher _passwordHasher;

        public AuthManager(IRepository context)
        {
            db = context;
            _passwordHasher = new Hasher();
        }

        public ResponseData SignIn(string email, string passWord)
        {

            var user = db.FirstOrDefault<UserModel>(w => w.email == email);

            if(user != null) 
            {
                var verifyPass = _passwordHasher.VerifyHashedPassword(user.password, passWord);

                if (verifyPass)
                {
                    var authUser = Authenticate(user.email);

                    var response = new ResponseData
                    {
                        AccessToken = authUser,
                        Status = "OK",
                        Message = "Авторизован",
                        User = new LoginModel
                        {
                            Id = user.id,
                            Email = user.email,
                            Login = user.login,
                            FirstName = user.first_name,
                            LastName = user.last_name,
                            MiddleName = user.middle_name
                        }
                    };

                    return response;
                }

                return new ResponseData { Status = "ERROR", Message = "Неверный логин или пароль" };
            }
            else
            {
                return new ResponseData { Status = "ERROR", Message = "Пользователь не найден" };
            }
        }

        public ResponseData Register(JObject data)
        {
            var model = data.ToObject<RegisterModel>();
            if (model != null)
            {
                UserModel user = db.FirstOrDefault<UserModel>(w => w.email == model.Email);
                if (user == null)
                {
                    var hashPassword = _passwordHasher.HashPassword(model.Password);
                    // добавляем пользователя в бд
                    db.Add<UserModel>(new UserModel
                    {
                        email = model.Email,
                        password = hashPassword,
                        first_name = model.FirstName,
                        last_name = model.LastName,
                        middle_name = model.MiddleName,
                        login = model.Login
                    });

                    db.SaveChangesAsync();

                    var authUser = Authenticate(model.Email);

                    var response = new ResponseData
                    {
                        AccessToken = authUser,
                        Status = "OK",
                        Message = "Пользователь зарегистрирован",
                        User = new LoginModel
                        {
                            Email = model.Email,
                            Login = model.Login,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            MiddleName = model.MiddleName
                        }
                    };

                    return response;
                }
                else
                    return new ResponseData { Status = "ERROR", Message = "Данный пользователь уже зарегистрирован" };
            }
            return new ResponseData { Status = "ERROR", Message = "Неверные данные" };
        }

        private string Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: claimsIdentity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}
