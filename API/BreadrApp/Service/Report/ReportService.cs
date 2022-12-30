using DataAccess.DBContext;
using Microsoft.EntityFrameworkCore;
using Service.Report.Dtos;
using Service.Report.Models;


namespace Service.Report
{
    public class ReportService : IReportService
    {

        private readonly BreadrDbContext _context;

        public ReportService(BreadrDbContext context)
        {
            _context = context;

        }

        public async Task<GetReportsResponse> GetAllReports(GetReportsRequest request)
        {
            GetReportsResponse response = new GetReportsResponse()
            {
                Request = request
            };

            List<ReportDto> reports = await _context.Receipts.Select(x => new ReportDto
            {
                ReportId = x.ReceiptId,
                Date = x.Date,
                Description = x.Description,
                UserName = x.User.Username,
                GateName = x.Gate.GateId


            }).ToListAsync();

            response.Reports = reports;
            response.Success = true;

            return response;
        }

        public async Task<GetReportsResponse> GetReportsByUser(GetReportsRequest request)
        {
            GetReportsResponse response = new GetReportsResponse()
            {
                Request = request
            };

            List<ReportDto> reports = await _context.Receipts.Where(x=>x.UserId==request.UserId).Select(x => new ReportDto
            {
                ReportId = x.ReceiptId,
                Date = x.Date,
                Description = x.Description,
                UserName = x.User.Username,
                GateName = x.Gate.GateId


            }).ToListAsync();

            response.Reports = reports;
            response.Success = true;

            return response;
        }        


        public Task<KeepAliveResponse> KeepAlive(KeepAliveRequest request)
        {
            throw new NotImplementedException();
        }


        public Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
