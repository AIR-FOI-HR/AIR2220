using Breadr.Service.ProfileManager.Models;

namespace Breadr.Service.ProfileManager
{
    public interface IProfileManagerService
    {
        Task<UserLoginResponse> UserLogin(UserLoginRequest request);
        Task<UserRegisterResponse> UserRegister(UserRegisterRequest request);

    }
}
