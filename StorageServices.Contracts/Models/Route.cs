using System;
using System.Collections.Generic;
using System.Text;

namespace StorageServices.Contracts.Models
{
    public class Route
    {
        public Guid Id { get; set; }

        public int DriverId { get; set; }

        public Guid? StartCoord { get; set; }

        public Guid? EndCoord { get; set; }
    }
}
