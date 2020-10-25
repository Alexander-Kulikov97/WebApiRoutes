using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace WebApiRoutes.Data.Test.FakeData
{
    public class FakeDatabase : DbContext
    {
        public FakeDatabase(DbContextOptions options) : base(options) { }

        public DbSet<UserEntity> Movies { get; set; }
    }
}
