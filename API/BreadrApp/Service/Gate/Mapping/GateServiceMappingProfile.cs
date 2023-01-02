using AutoMapper;
using Breadr.Service.Gate.Dtos;

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
