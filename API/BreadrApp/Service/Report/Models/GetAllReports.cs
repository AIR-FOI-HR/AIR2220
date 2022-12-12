using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Breadr.Core.Domain;
using Service.Report.Dtos;

namespace Service.Report.Models
{
    public class GetAllReportsRequest: RequestBase
    {

    }

    public class GetAllReportsResponse : ResponseBase<GetAllReportsRequest>
    {
        public List<ReportDto> AllReports { get; set; }
    }
}
