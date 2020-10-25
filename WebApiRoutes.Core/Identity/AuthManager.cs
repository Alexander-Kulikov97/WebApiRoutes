using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiRoutes.Data.Context;
using WebApiRoutes.Data.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Linq;
using WebApiRoutes.Core.Models;
using Newtonsoft.Json.Linq;

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

        public ResponseUser SignIn(string email, string passWord)
        {

            var user = db.FirstOrDefault<UserModel>(w => w.email == email);

            if(user != null) 
            {
                var verifyPass = _passwordHasher.VerifyHashedPassword(user.password, passWord);

                if (verifyPass)
                {
                    var authUser = Authenticate(user.email);

                    var response = new ResponseUser
                    {
                        ClaimsIdentity = authUser,
                        data = new ResponseData
                        {
                            Status = "success",
                            User = new LoginModel
                            {
                                Id = user.id,
                                Email = user.email,
                                Login = user.login,
                                FirstName = user.first_name,
                                LastName = user.last_name,
                                MiddleName = user.middle_name
                            }
                        }
                    };

                    return response;
                }

                return new ResponseUser { data = new ResponseData { Status = "ERROR", Message = "Неверный логин или пароль" } };
            }
            else
            {
                return new ResponseUser { data = new ResponseData { Status = "ERROR", Message = "Пользователь не найден" } };
            }
        }

        public ResponseUser Register(JObject data)
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

                    var response = new ResponseUser
                    {
                        ClaimsIdentity = authUser,
                        data = new ResponseData
                        {
                            Status = "success",
                            User = new LoginModel
                            {
                                Email = model.Email,
                                Login = model.Login,
                                FirstName = model.FirstName,
                                LastName = model.LastName,
                                MiddleName = model.MiddleName
                            }
                        }
                    };

                    return response;
                }
                else
                    return new ResponseUser { data = new ResponseData { Status = "ERROR", Message = "Данный пользователь уже зарегистрирован" } };
            }
            return new ResponseUser { data = new ResponseData { Status = "ERROR", Message = "Неверные данные" } };
        }

        private ClaimsIdentity Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            return new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
