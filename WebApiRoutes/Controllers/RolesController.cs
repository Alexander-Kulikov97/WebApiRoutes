using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiRoutes.Core.Role;

namespace WebApiRoutes.Controllers
{
    [Produces("application/json")]
    [Route("api/roles")]
    [ApiController]
    public class RolesController : BaseController
    {
        private readonly IRoleManager _roleManager;

        public RolesController(IRoleManager roleManager)
        {
            _roleManager = roleManager;
        }

        /// <summary>
        /// Получить все роли
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200"></response>
        [Authorize(Roles = "admin")]
        [Route("getallroles")]
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            return Json(_roleManager.GetAllRoles());
        }

        /// <summary>
        /// Получить роль 
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200"></response>
        [Authorize(Roles = "admin")]
        [Route("getrole/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetRole(Guid id)
        {
            return Json(_roleManager.GetRoleById(id));
        }
    }
}
