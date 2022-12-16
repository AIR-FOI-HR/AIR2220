using Breadr.Core.Domain;
using Service.Report.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Report.Models
{
    public class GetAllInactiveGatesRequest : RequestBase
    {

    }
    public class GetAllInactiveGatesResponse : ResponseBase<GetAllInactiveGatesRequest>
    {
        public List<ReportDto> AllInactiveGates { get; set; }
    }
}