using AutoMapper;
using Breadr.Service.Gate.Dtos;
using Breadr.Service.ProfileManager.Dtos;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
