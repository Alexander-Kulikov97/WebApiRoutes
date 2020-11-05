using WebApiRoutes.Core.Identity;
using Xunit;
using WebApiRoutes.Data.Repositories;
using WebApiRoutes.Core.Test.FakeDB;

namespace WebApiRoutes.Core.Test
{
    public class AuthManagerTest
    {
        private readonly IHasher _passwordHasher;
        private readonly IRepository _repository;
        private readonly IAuthManager _authManager;
        public AuthManagerTest()
        {
            _passwordHasher = new Hasher();
            var _context = DbInitializer.CreateFakeDatabase();
            _repository = new RepositoryBase(_context);
            _authManager = new AuthManager(_repository);
        }

        [Fact]
        public void HashCreateAndVerifyPassword_TrueReturn_Test()
        {
            // Arrange
            var password = "dfIF9rlbkk214sdg";

            // Act
            string hashPassword = _passwordHasher.HashPassword(password);
            var isTruePasword = _passwordHasher.VerifyHashedPassword(hashPassword, password);

            // Assert
            Assert.True(isTruePasword == true);
        }

        [Fact]
        public void HashCreateAndVerifyPassword_FalseReturn_Test()
        {
            // Arrange
            var passwordTrue = "TygfERg234";
            var passwordfalse = "123";

            // Act
            string hashPassword = _passwordHasher.HashPassword(passwordTrue);
            var isTruePasword = _passwordHasher.VerifyHashedPassword(hashPassword, passwordfalse);

            // Assert
            Assert.True(isTruePasword == false);
        }
    }
}
