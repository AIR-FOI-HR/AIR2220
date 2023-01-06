using AutoMapper;
using Breadr.Core.Web;
using Breadr.MQTT;
using Breadr.Service.Gate;
using Breadr.Service.Gate.Models;
using Breadr.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Breadr.Controllers
{
    [ApiController]
    public class GateController : ApiControllerBase
    {

        private readonly IGateService _gateService;
        private readonly IMapper _mapper;

        public GateController(IGateService gateService, IMapper mapper)
        {
            _gateService = gateService;
            _mapper = mapper;

            MqttReceiver.KeepAliveListener(this);
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

        [HttpGet("Gate/{gateId}")]
        public async Task<IActionResult> GetGate(string gateId)
        {

            GateRequest request = CreateServiceRequest<GateRequest>();
            request.GateId = gateId;
            GateResponse response = await _gateService.GetGate(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Gate);
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

        
        [HttpPost("Gate")]
        public async Task<IActionResult> AddNewGate([FromBody] GateViewModel gate)
        {

            GateRequest request = _mapper.Map(gate,CreateServiceRequest<GateRequest>());
            GateResponse response = await _gateService.AddNewGate(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Gate); 
        }


        // todo: dodaj usera
        [HttpPut("Gate")]
        public async Task<IActionResult> EditGate([FromBody] GateViewModel gate) 
        {

            GateRequest request = _mapper.Map(gate,CreateServiceRequest<GateRequest>());
            GateResponse response = await _gateService.EditGate(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Gate);
        }

        public async Task<IActionResult> Keepalive(GateViewModel gate)
        {

            GateRequest request = _mapper.Map(gate, CreateServiceRequest<GateRequest>());
            GateResponse response = await _gateService.EditGate(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Gate);
        }


        // todo: dodaj usera
        [HttpPatch("DisableGate/{gateId}")]
        public async Task<IActionResult> DisableGate([FromRoute] string gateId) 
        {

            GateRequest request = CreateServiceRequest<GateRequest>();
            request.GateId = gateId;
            GateResponse response = await _gateService.DisableGate(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Gate);
        }


        // todo: dodaj usera
        [HttpPatch("EnableGate/{gateId}")]
        public async Task<IActionResult> EnableGate(string gateId) //JSON ARRAY???
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
