using Breadr.Core.Domain;
using Breadr.Service.ProfileManager.Dtos;

namespace Breadr.Service.ProfileManager.Models
{
    public class UserLoginRequest : RequestBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class UserLoginResponse : ResponseBase<UserLoginRequest>
    {
        public UserDto User { get; set; }
    }
}
