using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Breadr.Core.Domain;
using Service.Report.Dtos;

namespace Service.Report.Models
{
    public class GetReportsRequest: RequestBase
    {
        public int UserId { get; set; }
    }

    public class GetReportsResponse : ResponseBase<GetReportsRequest>
    {
        public List<ReportDto> Reports { get; set; }
    }
}
