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

        DriverInfoModel GetDriver(int id);

        void SetStatusDriver(int id, string status);

        string GetStatusDriver(int id);

        void SetTimeSecondsDriver(int id, int timeSeconds);
    }
}
