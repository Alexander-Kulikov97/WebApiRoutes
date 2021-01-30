
namespace WebApiRoutes.Core.Models
{
    public class AuthUser
    {
        public string AccessToken { get; set; }

        public string Message { get; set; }

        public UserModel User { get; set;}
    }
}
