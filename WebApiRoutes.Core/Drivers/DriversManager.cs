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

            _driverServices.AddDriverInfo(model);

        }
    }
}
