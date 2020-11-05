using WebApiRoutes.Context.Internals;

namespace WebApiRoutes.Context
{
    public interface IRepository : IReadonlyRepository, IInternalRepository { }
}
