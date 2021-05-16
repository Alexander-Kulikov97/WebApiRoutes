using System;
using System.Collections.Generic;
using System.Text;

namespace StorageServices.Contracts.Models
{
    public class DriverInfoModel : UserModel
    {
        /// <summary>
        /// Номер ТС
        /// </summary>
        public string VehicleNumber { get; set; }
        /// <summary>
        /// Тип ТС
        /// </summary>
        public string VehicleType { get; set; }

        public string Status { get; set; }

        public int? TimeSeconds { get; set; }
    }
}
