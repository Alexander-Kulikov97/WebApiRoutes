using Microsoft.EntityFrameworkCore;

namespace StoregeServices.Context
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions options) : base(options) { }
    }
}
