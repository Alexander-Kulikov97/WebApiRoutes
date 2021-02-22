using StorageServices.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageServices.Contracts.Roles
{
    public interface IRolesServices
    {
        RoleModel GetRoleById(Guid id);

        List<RoleModel> GetAllRole();
    }
}
