namespace WebApiRoutes.Core.Identity
{
    public interface IHasher
    {
        string HashPassword(string password);

        bool VerifyHashedPassword(string hashedPassword, string providedPassword);
    }
}
