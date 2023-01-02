using AutoMapper;
using Breadr.Service.Gate.Models;
using Breadr.Service.ProfileManager.Models;
using Breadr.ViewModels;

namespace Breadr.Mapping
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<GateViewModel, GateRequest>();
            CreateMap<UserLoginViewModel, UserLoginRequest>();
            CreateMap<UserRegistrationViewModel, UserRegisterRequest>();
        }
    }
}
