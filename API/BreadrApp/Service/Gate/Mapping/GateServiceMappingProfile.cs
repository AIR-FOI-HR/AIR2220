using AutoMapper;
using Breadr.Service.Gate.Dtos;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadr.Service.Gate.Mapping
{
    public class GateServiceMappingProfile : Profile
    {
        public GateServiceMappingProfile()
        {
            CreateMap<DataAccess.Models.Gate, GateDto>();
        }
    }
}
