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

        public class GateRequest : RequestBase
        {
            public string GateId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public long Latitude { get; set; }
            public long Longitude { get; set; }
            public decimal Price { get; set; }
        }
        public class GateResponse : ResponseBase<GateRequest>
        {
            public GateDto Gate { get; set; }
        }
}
