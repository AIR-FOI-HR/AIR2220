using Breadr.Service.Gate.Models;
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
        Task<GetReportsResponse> GetAllReports(GetReportsRequest request);
        Task<GetReportsResponse> GetReportsByUser(GetReportsRequest request);
        Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request);
        Task<KeepAliveResponse> KeepAlive(KeepAliveRequest request);

    }
}
