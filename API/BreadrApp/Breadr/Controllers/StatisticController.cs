using AutoMapper;
using Breadr.Core.Web;
using Breadr.Service.Gate;
using Breadr.Service.Gate.Models;
using Breadr.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Service.Report;
using Service.Report.Models;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Web.Helpers;
using Service.Statistic;
using Breadr.Service.Statistic.Models;

namespace Breadr.Controllers
{
    [ApiController]
    public class StatisticController : ApiControllerBase
    {

        private readonly IStatisticService _statisticService;
        private readonly IMapper _mapper;

        public StatisticController(IStatisticService reportService, IMapper mapper)
        {
            _statisticService = reportService;
            _mapper = mapper;
        }

        [HttpGet("GetStatistics")]
        public async Task<IActionResult> GetStatistics()
        {

            StatisticsRequest request = CreateServiceRequest<StatisticsRequest>();
            StatisticsResponse response = await _statisticService.GetStatistics(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Statistics);
        }

        [HttpGet("GetSuccessfulPaymentStatistics")]
        public async Task<IActionResult> GetSuccessfulPaymentStatistics()
        {

            StatisticsRequest request = CreateServiceRequest<StatisticsRequest>();
            StatisticsResponse response = await _statisticService.GetSuccessfulPaymentStatistics(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Statistics);
        }

        [HttpGet("GetUnsuccessfulPaymentStatistics")]
        public async Task<IActionResult> GetUnsuccessfulPaymentStatistics()
        {

            StatisticsRequest request = CreateServiceRequest<StatisticsRequest>();
            StatisticsResponse response = await _statisticService.GetUnsuccessfulPaymentStatistics(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Statistics);
        }


        [HttpGet("GetStatisticsByTime/{time}")]
        public async Task<IActionResult> GetStatisticsByTime([FromRoute] int time)
        {

            StatisticsByTimeRequest request = CreateServiceRequest<StatisticsByTimeRequest>();
            request.Time = time;
            StatisticsByTimeResponse response = await _statisticService.GetStatisticsByTime(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Statistics);
        }
    }
}
