using StorageServices.Contracts.Driver;
using StorageServices.Contracts.Models;
using StoregeServices.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace StorageServices.Driver
{
    public class DriverServices : IDriverServices
    {
        private readonly IRepository _db;

        public DriverServices(IRepository context)
        {
            _db = context;
        }

        public List<DriverInfoModel> GetAllDrivers()
        {
            return _db.GetAll<DriverInfoModel>($"SELECT u.Id as Id, first_name as FirstName, last_name as LastName, middle_name as MiddleName" +
                $", email as Email, login as Login, d.vehiclenumber as VehicleNumber, d.vehicletype as VehicleType " +
                $"FROM t_user u join t_drivers d on u.Id = d.userId", null, CommandType.Text);
        }

        public DriverInfoModel GetDriverById(int id)
        {
            return _db.Get<DriverInfoModel>($"SELECT u.Id as Id, first_name as FirstName, last_name as LastName, middle_name as MiddleName" +
                $", email as Email, login as Login, d.vehiclenumber as VehicleNumber, d.vehicletype as VehicleType " +
                $"FROM t_user u join t_drivers d on u.Id = d.userId where d.userId = {id}", null, CommandType.Text);
        }

        public void AddDriverInfo(DriverInfoModel model)
        {
            if(model != null)
            {
                _db.Execute($"INSERT INTO [dbo].[t_drivers] ([userId], [vehiclenumber], [vehicletype]) " +
                    $"VALUES({model.Id}, '{model.VehicleNumber}', '{model.VehicleType}')", null, CommandType.Text);
            }
        }
    }
}
