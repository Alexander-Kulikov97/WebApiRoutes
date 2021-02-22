using StorageServices.Contracts.Models;
using StorageServices.Contracts.Roles;
using StoregeServices.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageServices.Roles
{
    public class RolesServices : IRolesServices
    {
        private readonly IRepository _db;

        public RolesServices(IRepository context)
        {
            _db = context;
        }

        public RoleModel GetRoleById(Guid id)
        {
            return _db.Get<RoleModel>($"SELECT [id] as Id,[name] as Name FROM[t_role] where id = '{id}'", null, System.Data.CommandType.Text);
        }

        public List<RoleModel> GetAllRole()
        {
            return _db.GetAll<RoleModel>($"SELECT [id] as Id,[name] as Name FROM[t_role]", null, System.Data.CommandType.Text);
        }
    }
}
