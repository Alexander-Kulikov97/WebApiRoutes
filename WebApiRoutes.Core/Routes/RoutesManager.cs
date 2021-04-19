using StorageServices.Routes;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiRoutes.Core.Models;
using System.Linq;
using StorageServices.Contracts.Models;
using StorageServices.Contracts.Driver;

namespace WebApiRoutes.Core.Routes
{
    public class RoutesManager : IRoutesManager
    {
        private readonly IRoutesServices _routesServices;
        private readonly IDriverServices _driverServices;

        public RoutesManager(IRoutesServices routesServices,
                             IDriverServices driverServices)
        {
            _routesServices = routesServices;
            _driverServices = driverServices;
        }


        public Models.Route GetRoute(int driverId)
        {
            var route = _routesServices.GetRouteByDriver(driverId);

            if(route == null)
            {
                throw new Exception("Не найдены маршруты у водителя!");
            }

            var point = _routesServices.GetPointsByRoute(route.Id);
            var endCoord = point.FirstOrDefault(w => w.Id == route.EndCoord);
            var startCoord = point.FirstOrDefault(w => w.Id == route.StartCoord);

            return new Models.Route()
            {
                Id = route.Id,
                DriverId = route.DriverId,
                End = endCoord,
                Start = startCoord,
                Points = point,
            };
        }

        public void InsertPoint(Point point)
        {
            _routesServices.InsertPoint(point);
        }

        public StorageServices.Contracts.Models.Route InsertStartPoint(Point point, int driverId)
        {
            if(point == null)
            {
                throw new Exception("точка не найдена");
            }

            var driver = _driverServices.GetDriverById(driverId);

            if(driver == null)
            {
                throw new Exception("Такого водителя не существует! ");
            }

            var route = _routesServices.GetRouteByDriver(driverId);

            var resultPoint = _routesServices.InsertPoint(point);

            if(resultPoint != null)
            {
                route.StartCoord = resultPoint;
            }

            return _routesServices.UpdateRoute(route);
        }

        public StorageServices.Contracts.Models.Route InsertEndPoint(Point point, int driverId)
        {
            if (point == null)
            {
                throw new Exception("точка не найдена");
            }

            var driver = _driverServices.GetDriverById(driverId);

            if (driver == null)
            {
                throw new Exception("Такого водителя не существует! ");
            }

            var route = _routesServices.GetRouteByDriver(driverId);

            var resultPoint = _routesServices.InsertPoint(point);

            if (resultPoint != null)
            {
                route.EndCoord = resultPoint;
            }

            return _routesServices.UpdateRoute(route);
        }

        /// <summary>
        /// Добавление маршрута новому водителю
        /// </summary>
        /// <param name="model"></param>
        public StorageServices.Contracts.Models.Route InsertRoute(int driverId)
        {
            _routesServices.DeleteRoute(driverId);


            var route = new StorageServices.Contracts.Models.Route()
            {
                DriverId = driverId,
            };

            return _routesServices.InsertRouteWithoutDots(route);

            
            //ponts.Add(new Point { 
            //    Lat = model.EndPoint.Lat,
            //    Lng = model.EndPoint.Lng,
            //    RouteId = routesdb.Id,
            //    Speed = model.EndPoint.Speed,
            //});

            //ponts.Add(new Point
            //{
            //    Lat = model.StartPoint.Lat,
            //    Lng = model.StartPoint.Lng,
            //    RouteId = routesdb.Id,
            //    Speed = model.StartPoint.Speed,
            //});

            //foreach (var item in model.DriverPoint)
            //{
            //    ponts.Add(new Point
            //    {
            //        Lat = item.Lat,
            //        Lng = item.Lng,
            //        RouteId = routesdb.Id,
            //        Speed = item.Speed,
            //    });
            //}
        }
    }
}
