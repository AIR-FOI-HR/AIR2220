using Service.Report.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Report
{
    public class ReportService : IReportService
    {
        public Task<GetAllReportsResponse> GetAllReports(GetAllReportsRequest request)
        {
            GetAllReportsResponse response = new GetAllReportsResponse()
            {
                Request = request
            };
        }
    }
}
