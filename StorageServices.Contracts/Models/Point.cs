using System;
using System.Collections.Generic;
using System.Text;

namespace StorageServices.Contracts.Models
{
    public class Point
    {
        public Guid Id { get; set; }

        public Guid RouteId { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public double Speed { get; set; }
    }
}
