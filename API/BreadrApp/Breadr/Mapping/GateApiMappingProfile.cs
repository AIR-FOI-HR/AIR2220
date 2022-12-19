using AutoMapper;
using Breadr.Service.Gate.Models;
using Breadr.ViewModels;

namespace Breadr.Mapping
{
    public class GateApiMappingProfile : Profile
    {
        public GateApiMappingProfile()
        {
            CreateMap<GateViewModel, GateRequest>();
        }
    }
}
