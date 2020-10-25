using System;
using WebApiRoutes.Data.Repositories.Internals;

namespace WebApiRoutes.Data.Repositories
{
    public interface IRepository : IReadonlyRepository, IInternalRepository { }
}
