using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StorageServices.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiRoutes.Core.Models;
using WebApiRoutes.Core.Routes;

namespace WebApiRoutes.Controllers
{
    [Produces("application/json")]
    [Route("api/routes")]
    [ApiController]
    public class RoutesController : BaseController
    {
        private readonly IRoutesManager _routesManager;

        public RoutesController(IRoutesManager routesManager)
        {
            _routesManager = routesManager;
        }

        /// <summary>
        /// Получить маршрут
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200"></response>
        //[Authorize(Roles = "admin")]
        [Route("getroute")]
        [HttpGet]
        public async Task<IActionResult> GetRoute(int driverId)
        {
            return Json(_routesManager.GetRoute(driverId));
        }

        /// <summary>
        /// Новый маршрут
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200"></response>
        //[Authorize(Roles = "admin")]
        [Route("insertroute/{driverId}")]
        [HttpPost]
        public async Task<IActionResult> InsertRoute(int driverId)
        {

            _routesManager.InsertRoute(driverId);

            return Json("Маршрут добавлен", 200);
        }

        /// <summary>
        /// Добавить точку
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200"></response>
        //[Authorize(Roles = "admin")]
        [Route("insertpoint")]
        [HttpPost]
        public async Task<IActionResult> InsertPoint([FromBody] Point data)
        {
            if (data != null)
            {
                //ar model = data.ToObject<RouteRequest>();

                _routesManager.InsertPoint(data);

                return Json("Точка добавлена", 200);
            }
            return Json("Неверные данные", 400);
        }

        /// <summary>
        /// Добавить стартовую точку
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200"></response>
        //[Authorize(Roles = "admin")]
        [Route("insertstartpoint/{driverId}")]
        [HttpPost]
        public async Task<IActionResult> InsertStartPoint(int driverId, [FromBody] Point data)
        {
            if (data != null)
            {
                //ar model = data.ToObject<RouteRequest>();

                _routesManager.InsertStartPoint(data, driverId);

                return Json("Точка добавлена", 200);
            }
            return Json("Неверные данные", 400);
        }

        /// <summary>
        /// Добавить конечную точку
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200"></response>
        //[Authorize(Roles = "admin")]
        [Route("insertendpoint/{driverId}")]
        [HttpPost]
        public async Task<IActionResult> InsertEndPoint(int driverId, [FromBody] Point data)
        {
            if (data != null)
            {
                //ar model = data.ToObject<RouteRequest>();

                _routesManager.InsertEndPoint(data, driverId);

                return Json("Точка добавлена", 200);
            }
            return Json("Неверные данные", 400);
        }
    }
}
