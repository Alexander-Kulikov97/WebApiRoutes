using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiRoutes.Core.Models
{
    public class DriverModel : UserModel
    {
        /// <summary>
        /// Номер ТС
        /// </summary>
        public string VehicleNumber { get; set; }
        /// <summary>
        /// Тип ТС
        /// </summary>
        public string VehicleType { get; set; }
    }
}
