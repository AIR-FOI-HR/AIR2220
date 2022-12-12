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


        public async Task<GetAllReportsResponse> GetAllReports(GetAllReportsRequest request)
        {
            GetAllReportsResponse response = new GetAllReportsResponse()
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

            response.AllReports = reports;
            response.Success = true;

            return response;
        }
    }
}
