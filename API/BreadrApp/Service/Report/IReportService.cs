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
        /*Task<GetReportsByUserResponse> GetReportsByUser(GetReportsByUserRequest request);
        Task<GetSaltByEmailResponse> GetSaltByEmail(GetSaltByEmailRequest request);
        Task<LoginUserResponse> LoginUser(LoginUserRequest request);
        Task<RegisterUserResponse> RegisterUser(RegisterUserResponse register);
        Task<KeepAliveResponse> KeepAlive(KeepAliveRequest request);
        Task<GetAllGatesResponse> GetAllGates(GetAllGatesRequest request);
        Task<GetAllActiveGatesResponse> GetAllActiveGates(GetAllActiveGatesRequest request);
        Task<GetAllInactiveGatesResponse> GetAllInactiveGates(GetAllInactiveGatesRequest request);
        Task<AddNewGateResponse> AddNewGate(AddNewGateRequest request);
        Task<EditGateResponse> EditGate(EditGateRequest request);
        Task<DisableGateResponse> DisableGate(DisableGateRequest request);
        Task<EnableGateResponse> EnableGate(EnableGateRequest request);*/

    }
}
