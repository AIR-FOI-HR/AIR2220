using Breadr.Core.Domain;
using Service.Report.Dtos;
using Service.Report.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Report.Models
{
    public class GetReportsByUserRequest: RequestBase
    {

    }
    public class GetReportsByUserResponse : ResponseBase<GetReportsByUserRequest>
    {
        public List<ReportDto> Reports { get; set; }
    }
}
