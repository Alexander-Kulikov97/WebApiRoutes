using StorageServices.Contracts.Models;
using StoregeServices.Contracts.Models;
using System.Collections.Generic;

namespace StorageService.Contracts.Auth
{
    public interface IUserServices
    {
        UserAuthModel GetLoginUser(string email);

        void CreateUser(UserAuthModel model);

        List<UserAuthModel> GetAllUsers();

        UserModel GetUserById(int id);
    }
}
