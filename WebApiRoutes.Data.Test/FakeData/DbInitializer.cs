using Microsoft.EntityFrameworkCore;

namespace WebApiRoutes.Data.Test.FakeData
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
            context.Movies.Add(new UserEntity { email = "ivan@mail.ru", first_name = "Иван", last_name = "Иванов", login = "Ivan", middle_name = "Иванович", password = "123" });
            context.SaveChanges();
        }
    }
}
