using StorageService.Contracts.Auth;
using StorageServices.Contracts.Driver;
using StorageServices.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiRoutes.Core.Models;

namespace WebApiRoutes.Core.Drivers
{
    public class DriversManager : IDriversManager
    {
        private readonly IDriverServices _driverServices;
        private readonly IUserServices _userServices;

        public DriversManager(IDriverServices driverServices, IUserServices userServices)
        {
            _driverServices = driverServices;
            _userServices = userServices;
        }

        public List<DriverInfoModel> GetAllDrivers()
        {
            return _driverServices.GetAllDrivers();
        }

        public void AddDriver(DriverInfoModel model)
        {
            if(model.VehicleNumber == null)
            {
                throw new Exception("Отсутствует номер машины");
            }

            if (model.VehicleType == null)
            {
                throw new Exception("Отсутствует тип машины");
            }

            var user = _userServices.GetUserById(model.Id);

            if(user == null)
            {
                throw new Exception("Пользователь не найден");
            }

            var driver = _driverServices.GetDriverById(model.Id);

            if(driver != null)
            {
                throw new Exception("Водитель уже существут в БД");
            }

            _driverServices.AddDriverInfo(model);
            _userServices.UpdateUserRole(model.Id, Guid.Parse("e0528690-e98f-480b-ab63-e0d9b81b2b11"));

        }

        public DriverInfoModel GetDriver(int id)
        {
            return _driverServices.GetDriverById(id);
        }

        public void SetStatusDriver(int id, string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                throw new Exception("Неверный статус");
            }

            _driverServices.SetStatusDriverById(id, status);
        }

        public string GetStatusDriver(int id)
        {
            return _driverServices.GetStatusDriver(id);
        }

        public void SetTimeSecondsDriver(int id, int timeSeconds)
        {
            _driverServices.SetTimeSecondsDriver(id, timeSeconds);
        }
    }
}
