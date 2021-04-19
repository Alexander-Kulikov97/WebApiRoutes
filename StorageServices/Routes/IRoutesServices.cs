using StorageServices.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageServices.Routes
{
    public interface IRoutesServices
    {
        Route GetRouteByDriver(int driverId);

        List<Point> GetPointsByRoute(Guid routeId);

        Route InsertRouteWithoutDots(Route model);

        Guid InsertPoint(Point model);

        Route UpdateRoute(Route model);

        void DeleteRoute(int id);
    }
}
