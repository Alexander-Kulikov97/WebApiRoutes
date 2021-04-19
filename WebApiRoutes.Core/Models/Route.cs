using System;
using System.Collections.Generic;
using StorageServices.Contracts.Models;

namespace WebApiRoutes.Core.Models
{
    public class Route
    {
        public Guid Id { get; set; }

        public int DriverId { get; set; }

        public Point Start { get; set; }

        public Point End { get; set; }

        public List<Point> Points { get; set; }
    }
}
