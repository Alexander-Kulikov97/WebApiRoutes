using System.Threading.Tasks;
using WebApiRoutes.Data.Test.FakeData;
using Xunit;

namespace WebApiRoutes.Data.Test
{
    //public class Repository_Tests
    //{
    //    private readonly IRepository _repository;

    //    public Repository_Tests()
    //    {
    //        var _context = DbInitializer.CreateFakeDatabase();
    //        //_repository = new RepositoryBase(_context);
    //    }

    //    [Fact]
    //    public void Add_OneUser()
    //    {
    //        // Arrange
    //        var user = FackeUser.User;

    //        // Act
    //        //_repository.Add(user);
    //        //var result = _repository.SaveChanges();

    //        // Assert
    //        //Assert.True(result == 1);
    //    }

    //    [Fact]
    //    public void Add_ManyUser()
    //    {
    //        // Arrange
    //        var user = FackeUser.Users(5);

    //        // Act
    //        _repository.Add(user);
    //        var result = _repository.SaveChanges();

    //        // Assert
    //        Assert.True(result == 5);
    //    }

    //    [Fact]
    //    public void Remove_One_Entity()
    //    {
    //        // Arrange
    //        var user = First_Test();

    //        // Act
    //        _repository.Remove(user);
    //        var result = _repository.SaveChanges();

    //        // Assert
    //        Assert.True(result == 1);
    //    }

    //    [Fact]
    //    public void Remove_One_ById()
    //    {
    //        // Arrange
    //        var user = First_Test();

    //        // Act
    //        _repository.Remove<UserEntity>(user.id);
    //        var result = _repository.SaveChanges();

    //        // Assert
    //        Assert.True(result == 1);
    //    }

    //    [Fact]
    //    public UserEntity First_Test()
    //    {
    //        // Act
    //        var result = _repository.FirstOrDefault<UserEntity>();

    //        // Assert
    //        Assert.NotNull(result);

    //        return result;
    //    }
    //}
}
