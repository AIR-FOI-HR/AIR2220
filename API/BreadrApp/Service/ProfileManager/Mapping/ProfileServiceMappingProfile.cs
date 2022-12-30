using AutoMapper;
using Breadr.Service.ProfileManager.Dtos;
using DataAccess.Models;

namespace Breadr.Service.ProfileManager.Mapping
{

       public class ProfileServiceMappingProfile : Profile
       {
            public ProfileServiceMappingProfile()
            {
                CreateMap<User, UserDto>();
            }
       }
}
