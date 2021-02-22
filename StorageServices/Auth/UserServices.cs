using System;
using System.Collections.Generic;
using System.Data;
using StorageService.Contracts.Auth;
using StorageServices.Contracts.Models;
using StoregeServices.Contracts.Models;
using StoregeServices.Contracts.Repositories;

namespace StoregeServices.Auth
{
    public class UserServices : IUserServices
    {
        private readonly IRepository _db;

        public UserServices(IRepository context)
        {
            _db = context;
        }

        public UserAuthModel GetLoginUser(string email)
        {
            return _db.Get<UserAuthModel>($"select u.Id as Id, first_name as FirstName, last_name as LastName, middle_name as MiddleName, email as Email, password as Password, login as Login, r.id as RoleId from t_user u join t_role r on u.role_id = r.id where email = '{email}'", null, commandType: CommandType.Text);
        }

        public void CreateUser(UserAuthModel model)
        {
            if(model != null)
            {
                //var roleId = _db.Get<Guid>($"select id from t_role where name = '{model.RoleId}'", null, CommandType.Text);
                var sql = $"INSERT INTO [dbo].[t_user] ([first_name],[last_name],[middle_name],[email],[password],[login],[role_id]) VALUES (N'{model.FirstName}', N'{model.LastName}', N'{model.MiddleName}', '{model.Email}', '{model.Password}', '{model.Login}', '{model.RoleId}')";
                _db.Execute(sql, null, CommandType.Text);
            }
        }

        public List<UserAuthModel> GetAllUsers()
        {
            return _db.GetAll<UserAuthModel>("select Id as Id, first_name as FirstName, last_name as LastName, middle_name as MiddleName, email as Email, password as Password, login as Login, role_id as RoleId from t_user", null, CommandType.Text);
        }

        public UserModel GetUserById(int id)
        {
            return _db.Get<UserModel>($"select Id as Id, first_name as FirstName, last_name as LastName, middle_name as MiddleName" +
                $", email as Email, login as Login from t_user where Id = {id}", null, CommandType.Text);
        }

        public void UpdateUserRole(int userId, Guid roleId)
        {
            var sql = $"UPDATE [dbo].[t_user] SET[role_id] = '{roleId}' WHERE Id = {userId}";
            _db.Execute(sql, null, CommandType.Text);
        }
    }
}
