using Breadr.Core.Domain;
using Breadr.Service.ProfileManager.Dtos;
using Service.Report.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
