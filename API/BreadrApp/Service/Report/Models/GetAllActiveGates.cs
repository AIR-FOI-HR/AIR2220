using Breadr.Core.Domain;
using Service.Report.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Report.Models
{
    public class GetAllActiveGatesRequest : RequestBase
    {

    }
    public class GetAllActiveGatesResponse : ResponseBase<GetAllActiveGatesRequest>
    {
        public List<ReportDto> AllActiveGates { get; set; }
    }
}
