using Breadr.Core.Domain;
using Breadr.Service.Gate.Dtos;

namespace Breadr.Service.Gate.Models
{

        public class GatesRequest : RequestBase
        {

        }
        public class GatesResponse : ResponseBase<GatesRequest>
        {
            public List<GateDto> Gates { get; set; }
        }
    
}
