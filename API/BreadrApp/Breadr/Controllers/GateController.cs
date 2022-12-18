using AutoMapper;
using Breadr.Core.Web;
using Breadr.Service.Gate;
using Breadr.Service.Gate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Service.Report;
using Service.Report.Models;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Breadr.Controllers
{
    [ApiController]
    public class GateController : ApiControllerBase
    {

        private readonly IGateService _gateService;
        private readonly IMapper _mapper;

        public GateController(IGateService reportService, IMapper mapper)
        {
            _gateService = reportService;
            _mapper = mapper;
        }
        
        [HttpGet("AllGates")]
        public async Task<IActionResult> GetAllGates()
        {

            GatesRequest request = CreateServiceRequest<GatesRequest>();
            GatesResponse response = await _gateService.GetAllGates(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Gates);
        }

        [HttpGet("AllActiveGates")]
        public async Task<IActionResult> GetAllActiveGates()
        {

            GatesRequest request = CreateServiceRequest<GatesRequest>();
            GatesResponse response = await _gateService.GetAllActiveGates(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Gates);
        }
        
        [HttpGet("AllInactiveGates")]
        public async Task<IActionResult> GetAllInactiveGates()
        {

            GatesRequest request = CreateServiceRequest<GatesRequest>();
            GatesResponse response = await _gateService.GetAllInactiveGates(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Gates);
        }

        
        [HttpPost("AddNewGate")]
        public async Task<IActionResult> AddNewGate([FromBody] JsonArray payload) //JSON ARRAY???
        {

            GateRequest request = CreateServiceRequest<GateRequest>();
            GateResponse response = await _gateService.AddNewGate(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Gate); 
        }
        

        
        [HttpPut("EditGate/{gateId}")]
        public async Task<IActionResult> EditGate([FromBody] JsonArray payload, [FromRoute]string gateId) //JSON ARRAY???
        {

            GateRequest request = CreateServiceRequest<GateRequest>();
            GateResponse response = await _gateService.EditGate(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Gate);
        }
        

        
        [HttpPatch("DisableGate/{gateId}")]
        public async Task<IActionResult> DisableGate([FromBody] JsonArray payload, [FromRoute] string gateId) //JSON ARRAY???
        {

            GateRequest request = CreateServiceRequest<GateRequest>();
            GateResponse response = await _gateService.DisableGate(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Gate);
        }
        

        
        [HttpPatch("EnableGate/{gateId}")]
        public async Task<IActionResult> EnableGate(int gateId) //JSON ARRAY???
        {

            GateRequest request = CreateServiceRequest<GateRequest>();
            GateResponse response = await _gateService.EnableGate(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Gate);
        }
        


    }
}
