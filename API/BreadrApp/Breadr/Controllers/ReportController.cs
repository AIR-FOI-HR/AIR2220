using AutoMapper;
using Breadr.Core.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Service.Report;
using Service.Report.Models;
using System.Threading.Tasks;

namespace Breadr.Controllers
{
    [ApiController]
    public class ReportController : ApiControllerBase
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

            GetAllReportsRequest request = CreateServiceRequest<GetAllReportsRequest>();
            GetAllReportsResponse response = await _reportService.GetAllReports(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.AllReports);
        }

    }
}
