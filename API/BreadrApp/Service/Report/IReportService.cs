using Service.Report.Models;

namespace Service.Report
{
    public interface IReportService
    {
        Task<GetReportsResponse> GetAllReports(GetReportsRequest request);
        Task<GetReportsResponse> GetReportsByUser(GetReportsRequest request);
        Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request);

    }
}
