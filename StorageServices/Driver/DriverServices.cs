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
                $", email as Email, login as Login, d.vehiclenumber as VehicleNumber, d.vehicletype as VehicleType, d.timeSeconds as TimeSeconds " +
                $"FROM t_user u join t_drivers d on u.Id = d.userId", null, CommandType.Text);
        }

        public DriverInfoModel GetDriverById(int id)
        {
            return _db.Get<DriverInfoModel>($"SELECT u.Id as Id, first_name as FirstName, last_name as LastName, middle_name as MiddleName" +
                $", email as Email, login as Login, d.vehiclenumber as VehicleNumber, d.vehicletype as VehicleType, d.status as Status, d.timeSeconds as TimeSeconds " +
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

        public void SetStatusDriverById(int id, string status)
        {
            _db.Execute($"UPDATE [dbo].[t_drivers] SET [status] = '{status}' WHERE [userId] = {id}", null, CommandType.Text);
        }

        public string GetStatusDriver(int id)
        {
            var driver = _db.Get<DriverInfoModel>($"SELECT u.Id as Id, first_name as FirstName, last_name as LastName, middle_name as MiddleName" +
                $", email as Email, login as Login, d.vehiclenumber as VehicleNumber, d.vehicletype as VehicleType, d.status as Status " +
                $"FROM t_user u join t_drivers d on u.Id = d.userId where d.userId = {id}", null, CommandType.Text);

            if(driver != null)
            {
                return driver.Status;
            }

            return string.Empty;
        }

        public void SetTimeSecondsDriver(int id, int timeSeconds)
        {
            var sql = $"UPDATE [dbo].[t_drivers] SET [timeSeconds] = {timeSeconds} WHERE [userId] = {id}";
            _db.Execute(sql, null, CommandType.Text);
        }
    }
}
