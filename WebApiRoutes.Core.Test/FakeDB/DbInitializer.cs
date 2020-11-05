using Microsoft.EntityFrameworkCore;
using WebApiRoutes.Core.Identity;
using WebApiRoutes.Core.Test.Models;

namespace WebApiRoutes.Core.Test.FakeDB
{
    public class DbInitializer
    {
        public static FakeDatabase CreateFakeDatabase()
        {
            var builder = new DbContextOptionsBuilder<FakeDatabase>();
            builder.UseInMemoryDatabase("FakeDatabase");

            var context = new FakeDatabase(builder.Options);
            SeedDatabase(context);
            return context;
        }

        public static void SeedDatabase(FakeDatabase context)
        {
            context.Users.Add(new User
            {
                Email = "vasya@mail.ru",
                FirstName = "Кузьма",
                LastName = "Кузницов",
                MiddleName = "Сергеевич",
                Login = "Kuz",
                Password = new Hasher().HashPassword("123")
            });
            context.SaveChanges();
        }
    }
}
