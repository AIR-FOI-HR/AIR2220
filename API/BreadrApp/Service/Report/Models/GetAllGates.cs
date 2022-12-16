using Breadr.Core.Domain;
using Service.Report.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Report.Models
{
    public class GetAllGatesRequest : RequestBase
    {

    }
    public class GetAllGatesResponse : ResponseBase<GetAllGatesRequest>
    {
        public List<ReportDto> AllGates { get; set; }
    }
}