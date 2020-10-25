using Microsoft.EntityFrameworkCore;

namespace WebApiRoutes.Data.Context
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions options) : base(options) { }

        public DbSet<UserModel> t_user { get; set; }
    }
}
