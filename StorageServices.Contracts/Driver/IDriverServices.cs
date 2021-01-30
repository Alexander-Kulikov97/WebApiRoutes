using StorageServices.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageServices.Contracts.Driver
{
    public interface IDriverServices
    {
        List<DriverInfoModel> GetAllDrivers();

        void AddDriverInfo(DriverInfoModel model);
    }
}
