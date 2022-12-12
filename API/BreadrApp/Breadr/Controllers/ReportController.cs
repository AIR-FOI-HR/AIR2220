using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Service.Report;
using Service.Report.Models;

namespace Breadr.Controllers
{
    public class ReportController : Controller
    {

        private readonly IReportService _reportService;
        private readonly IMapper _mapper;

        public ReportController(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        [HttpGet("AllReports")]

        public async Task<IActionResult> GetAllReports()
        {
            GetAllReportsRequest request = new GetAllReportsRequest();




            return Ok();
        }
    }
}
