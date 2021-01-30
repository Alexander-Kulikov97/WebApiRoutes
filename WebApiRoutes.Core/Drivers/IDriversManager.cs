using StorageServices.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiRoutes.Core.Drivers
{
    public interface IDriversManager
    {
        List<DriverInfoModel> GetAllDrivers();

        void AddDriver(DriverInfoModel model);
    }
}
