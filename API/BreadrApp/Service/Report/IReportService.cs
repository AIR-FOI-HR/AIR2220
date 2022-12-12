using Service.Report.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Report
{
    public interface IReportService
    {
        Task<GetAllReportsResponse> GetAllReports(GetAllReportsRequest request);
    }
}
