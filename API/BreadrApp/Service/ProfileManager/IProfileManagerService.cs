using Breadr.Service.Gate.Models;
using Breadr.Service.ProfileManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadr.Service.ProfileManager
{
    public interface IProfileManagerService
    {
        Task<UserLoginResponse> UserLogin(UserLoginRequest request);
        Task<UserRegisterResponse> UserRegister(UserRegisterRequest request);

    }
}
