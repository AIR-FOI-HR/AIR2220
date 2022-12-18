using Breadr.Core.Domain;
using Breadr.Service.Gate.Dtos;
using Service.Report.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
