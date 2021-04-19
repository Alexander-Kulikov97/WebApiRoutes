using StorageServices.Contracts.Models;
using WebApiRoutes.Core.Models;

namespace WebApiRoutes.Core.Routes
{
    public interface IRoutesManager
    {
        Models.Route GetRoute(int driverId);

        StorageServices.Contracts.Models.Route InsertRoute(int driverId);

        StorageServices.Contracts.Models.Route InsertEndPoint(Point point, int driverId);

        void InsertPoint(Point point);

        StorageServices.Contracts.Models.Route InsertStartPoint(Point point, int driverId);
    }
}
