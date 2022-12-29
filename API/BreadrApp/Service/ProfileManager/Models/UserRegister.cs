using Breadr.Core.Domain;
using Breadr.Service.ProfileManager.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
