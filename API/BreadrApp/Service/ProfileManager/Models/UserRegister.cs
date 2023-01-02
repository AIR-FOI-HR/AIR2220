using Breadr.Core.Domain;
using Breadr.Service.ProfileManager.Dtos;

namespace Breadr.Service.ProfileManager.Models
{
    public class UserRegisterRequest : RequestBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
    public class UserRegisterResponse : ResponseBase<UserRegisterRequest>
    {
        public UserDto User { get; set; }
    }
}
