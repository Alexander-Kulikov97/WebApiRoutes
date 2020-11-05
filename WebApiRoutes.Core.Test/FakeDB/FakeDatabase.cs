using Microsoft.EntityFrameworkCore;
using WebApiRoutes.Core.Test.Models;

namespace WebApiRoutes.Core.Test.FakeDB
{
    public class FakeDatabase : DbContext
    {
        public FakeDatabase(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
