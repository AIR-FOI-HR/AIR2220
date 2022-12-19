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
using Breadr.Service.Statistic;

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

        
        //TODO dodaj endpointe za statistiku

        //prvi i zadnja dva sa cofluensa su modeli Statistics

        //2.,3. i 4. su svaki zasebno, dodani su u modelima

    }
}
