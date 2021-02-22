using StorageServices.Contracts.Models;
using StorageServices.Contracts.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiRoutes.Core.Role
{
    public class RoleManager : IRoleManager
    {
        private readonly IRolesServices _roleServices;

        public RoleManager(IRolesServices roleServices)
        {
            _roleServices = roleServices;
        }

        public List<RoleModel> GetAllRoles()
        {
            return _roleServices.GetAllRole();
        }

        public RoleModel GetRoleById(Guid id)
        {
            if(id == Guid.Empty && id == null)
            {
                new Exception("Постой ID");
            }

            return _roleServices.GetRoleById(id);
        }

    }
}
