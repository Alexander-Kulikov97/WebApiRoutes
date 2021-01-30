using System;
using System.Collections.Generic;
using System.Security.Claims;
using WebApiRoutes.Core.Models;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using StorageService.Contracts.Auth;
using StoregeServices.Contracts.Models;
using System.Linq;

namespace WebApiRoutes.Core.Identity
{
    public class AuthManager : IAuthManager
    {

        private readonly IUserServices _userServices;
        private readonly IHasher _passwordHasher;

        public AuthManager(IUserServices userServices)
        {
            _userServices = userServices;
            _passwordHasher = new Hasher();
        }

        public AuthUser SignIn(string email, string passWord)
        {
            var user = _userServices.GetLoginUser(email);

            if (user == null)
            {
                return new AuthUser { Message = "Пользователь не найден" };
            }

            var verifyPass = _passwordHasher.VerifyHashedPassword(user.Password, passWord);

            if (!verifyPass)
            {
                return new AuthUser { Message = "Неверный логин или пароль" };
            }
                
            var authUser = Authenticate(user.Email, user.Role);

            return new AuthUser
            {
                AccessToken = authUser,
                Message = "Авторизован",
                User = new UserModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Login = user.Login,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    MiddleName = user.MiddleName,
                }
            };
        }

        public AuthUser Register(JObject data)
        {
            var model = data.ToObject<RegisterModel>();
            if (model == null)
            {
                return new AuthUser { Message = "Неверные данные" };
            }

            var user = _userServices.GetLoginUser(model.Email);
            if (user != null)
            {
                return new AuthUser { Message = "Данный пользователь уже зарегистрирован" };
            }

            var hashPassword = _passwordHasher.HashPassword(model.Password);


            _userServices.CreateUser(new UserAuthModel
            {
                Email = model.Email,
                Password = hashPassword,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Login = model.Login,
                Role = "guest",
            });


            var authUser = Authenticate(model.Email, "guest");

            return new AuthUser
            {
                AccessToken = authUser,
                Message = "Пользователь зарегистрирован",
                User = new UserModel
                {
                    Email = model.Email,
                    Login = model.Login,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                }
            };         
        }

        public List<UserModel> GetAllUsers()
        {
            var users = _userServices.GetAllUsers();
            var result = new UserModel();

            if (users.Count == 0)
                return null;

            return users.Select(s => new UserModel
            {
                Id = s.Id,
                Email = s.Email,
                FirstName = s.FirstName,
                LastName = s.LastName,
                MiddleName = s.MiddleName,
                Login = s.Login,
            }).ToList();
        }

        private string Authenticate(string userName, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role),
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
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
