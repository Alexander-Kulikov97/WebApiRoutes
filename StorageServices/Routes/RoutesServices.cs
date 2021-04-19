using StorageServices.Contracts.Models;
using StoregeServices.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace StorageServices.Routes
{
    public class RoutesServices : IRoutesServices
    {
        private readonly IRepository _db;

        public RoutesServices(IRepository context)
        {
            _db = context;
        }

        public Route GetRouteByDriver(int driverId)
        {
            return _db.Get<Route>($"SELECT [id_route] as Id,[id_drivers] as DriverId,[start_coord] as StartCoord,[end_coord] as EndCoord " +
                $"FROM[WebApiRoutesDB].[dbo].[t_routes] WHERE [id_drivers] = {driverId}", null, CommandType.Text);
        }

        public List<Point> GetPointsByRoute(Guid routeId)
        {
            return _db.GetAll<Point>($"SELECT [id_point] as Id, [id_route] as RouteId, [lat] as Lat, [lng] as Lng, [speed] as Speed " +
                $"FROM[WebApiRoutesDB].[dbo].[t_point] WHERE[id_route] = '{routeId}'", null, CommandType.Text);
        }

        public Route InsertRouteWithoutDots(Route model)
        {
            _db.Insert<Route>($"INSERT INTO [dbo].[t_routes] ([id_drivers]) VALUES({model.DriverId})", null, CommandType.Text);

            return _db.Get<Route>($"SELECT [id_route] as Id,[id_drivers] as DriverId,[start_coord] as StartCoord,[end_coord] as EndCoord " +
                $"FROM[WebApiRoutesDB].[dbo].[t_routes] WHERE [id_drivers] = {model.DriverId}", null, CommandType.Text);
        }

        public Guid InsertPoint(Point model)
        {
            var sb = new StringBuilder();

            var lat = model.Lat.ToString(System.Globalization.CultureInfo.InvariantCulture);
            var lng = model.Lat.ToString(System.Globalization.CultureInfo.InvariantCulture);

            sb.Append("declare @Id uniqueidentifier set @Id = NEWID()" );
            sb.Append("INSERT INTO [dbo].[t_point] (id_point, [id_route], [lat], [lng], [speed]) VALUES(");
            sb.Append($"@Id, '{model.RouteId}', {lat}, {lng}, {model.Speed});");
            sb.Append("select @Id");

            return _db.Insert<Guid>(sb.ToString(), null, CommandType.Text);
        }

        public Route UpdateRoute(Route model)
        {
            var sb = new StringBuilder();
            sb.Append("UPDATE [dbo].[t_routes] SET ");

            if (model.StartCoord != null)
            {
                sb.Append($"[start_coord] = '{model.StartCoord}', ");
            }

            if (model.EndCoord != null)
            {
                sb.Append($"[end_coord] = '{model.EndCoord}' ");
            }

            sb.Append($"WHERE [id_route] = '{model.Id}'");

            return _db.Update<Route>(sb.ToString(), null, CommandType.Text);
        }

        public void DeleteRoute(int id)
        {
            _db.Execute($"DELETE FROM [dbo].[t_routes] WHERE [id_drivers] = {id}", null, CommandType.Text);
        }
    }
}
