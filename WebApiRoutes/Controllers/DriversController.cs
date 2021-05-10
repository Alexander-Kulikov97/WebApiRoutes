using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StorageServices.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiRoutes.Core.Drivers;

namespace WebApiRoutes.Controllers
{
    [Produces("application/json")]
    [Route("api/driver")]
    [ApiController]
    public class DriversController : BaseController
    {
        private readonly IDriversManager _driversManager;

        public DriversController(IDriversManager driversManager)
        {
            _driversManager = driversManager;
        }

        /// <summary>
        /// Получить всех водителей
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200"></response>
        [Authorize(Roles = "admin")]
        [Route("getalldrivers")]
        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            return Json(_driversManager.GetAllDrivers());
        }

        /// <summary>
        /// Добавить водителя
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "Id": "", //id user
        ///         "VehicleNumber": "",
        ///         "VehicleType": ""
        ///     }
        ///     
        /// </remarks>
        /// <response code="200"></response>
        [Authorize(Roles = "admin")]
        [Route("adddriver")]
        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] JObject data)
        {
            try
            {
                if (data != null)
                {
                    var model = data.ToObject<DriverInfoModel>();

                    _driversManager.AddDriver(model);

                    return Json("Водитель добавлен", 200);
                }
                return Json("Неверные данные", 400);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, 500);
            }
        }

        /// <summary>
        /// Получить водителя по ID
        /// </summary>
        /// <response code="200"></response>
        //[Authorize(Roles = "admin")]
        [Route("getdriver/{id}")]
        [HttpPost]
        public IActionResult GetdriverById(int id)
        {
            try
            {
                var driver = _driversManager.GetDriver(id);

                return Json(driver);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, 500);
            }
        }

        /// <summary>
        /// Получить статус водителя по ID
        /// </summary>
        /// <response code="200"></response>
        //[Authorize(Roles = "admin")]
        [Route("getstatusdriver/{id}")]
        [HttpPost]
        public IActionResult GetStatusdriverById(int id)
        {
            try
            {
                var driver = _driversManager.GetStatusDriver(id);

                return Json(driver);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, 500);
            }
        }

        /// <summary>
        /// Установить статус водителя
        /// </summary>
        /// <response code="200"></response>
        //[Authorize(Roles = "admin")]
        [Route("{id}/setstatusdriver/{status}")]
        [HttpPost]
        public IActionResult SetStatusDriver(int id, string status)
        {
            try
            {
                _driversManager.SetStatusDriver(id, status);
                return Json("Статус установлен", 200);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, 500);
            }
        }
    }
}
