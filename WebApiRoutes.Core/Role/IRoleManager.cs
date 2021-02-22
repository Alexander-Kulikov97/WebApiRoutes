using StorageServices.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiRoutes.Core.Role
{
    public interface IRoleManager
    {
        List<RoleModel> GetAllRoles();

        RoleModel GetRoleById(Guid id);
    }
}
