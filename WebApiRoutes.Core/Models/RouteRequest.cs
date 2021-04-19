using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiRoutes.Core.Models
{
    public class RouteRequest
    {
        //public List<PointCoord> DriverPoint { get; set; }

        public int DriverId { get; set; }

        //public PointCoord StartPoint { get; set; }

        //public PointCoord EndPoint { get; set; }
    }

    public class PointCoord
    {
        public double Lat { get; set; }

        public double Lng { get; set; }

        public double Speed { get; set; }
    }
}
