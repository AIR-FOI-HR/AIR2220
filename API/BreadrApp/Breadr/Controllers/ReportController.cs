using AutoMapper;
using Breadr.Core.Web;
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
    public class ReportController : ApiControllerBase
    {

        private readonly IReportService _reportService;
        private readonly IMapper _mapper;

        public ReportController(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }


        //REPORTS

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

        /*[HttpGet("ReportsByUser/{userId}")]
        public async Task<IActionResult> GetReportsByUser([FromRoute]int userId)
        {

            GetReportsByUserRequest request = CreateServiceRequest<GetReportsByUserRequest>(userId);
            GetReportsByUserResponse response = await _reportService.GetReportsByUser(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Report);
        }*/

        //LOGIN

        /*[HttpPost("GetSaltByEmail")]
        public async Task<IActionResult> GetSaltByEmail([FromBody]string email)
        {

            GetSaltByEmailRequest request = CreateServiceRequest<GetSaltByEmailRequest>(email);
            GetSaltByEmailResponse response = await _reportService.GetSaltByEmail(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Salt);
        }*/


        /*[HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody]JsonArray payload) //JSON ARRAY???
        {

            LoginUserRequest request = CreateServiceRequest<LoginUserRequest>(payload);
            LoginUserResponse response = await _reportService.LoginUser(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.User); //Return JSON with user data
        }*/

        //REGISTRATION

        /*[HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] JsonArray payload)
        {

            RegisterUserRequest request = CreateServiceRequest<RegisterUserRequest>(payload);
            RegisterUserResponse response = await _reportService.RegisterUser(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Status);
        }*/

        //MQTT

        /*[HttpGet("KeepAlive/{gateId}")]
        public async Task<IActionResult> KeepAlive(FromRoute]int gateId)
        {

            KeepAliveRequest request = CreateServiceRequest<KeepAliveRequest>(gateId);
            KeepAliveResponse response = await _reportService.KeepAlive(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Status); //return success or failure 
        }*/

        //GATE OPERATION

        /*[HttpGet("GetAllGates")]
        public async Task<IActionResult> GetAllGates()
        {

            GetAllGatesRequest request = CreateServiceRequest<GetAllGatesRequest>();
            GetAllGatesResponse response = await _reportService.GetAllGates(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.AllGates);
        }*/

        /*[HttpGet("GetAllActiveGates")]
        public async Task<IActionResult> GetAllActiveGates()
        {

            GetAllActiveGatesRequest request = CreateServiceRequest<GetAllActiveGatesRequest>();
            GetAllActiveGatesResponse response = await _reportService.GetAllActiveGates(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.AllActiveGates);
        }*/

        /*[HttpGet("GetAllInactiveGates")]
        public async Task<IActionResult> GetAllInactiveGates()
        {

            GetAllInactiveGatesRequest request = CreateServiceRequest<GetAllInactiveGatesRequest>();
            GetAllInactiveGatesResponse response = await _reportService.GetAllInactiveGates(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.AllInactiveGates);
        }*/

        /*[HttpPost("AddNewGate")]
        public async Task<IActionResult> AddNewGate([FromBody] JsonArray payload) //JSON ARRAY???
        {

            AddNewGateRequest request = CreateServiceRequest<AddNewGateRequest>(payload);
            AddNewGateResponse response = await _reportService.AddNewGate(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Status); 
        }*/

        /*[HttpPut("EditGate/{gateId}")]
        public async Task<IActionResult> EditGate([FromBody] JsonArray payload, [FromRoute]string gateId) //JSON ARRAY???
        {

            EditGateRequest request = CreateServiceRequest<EditGateRequest>(payload,gateId);
            EditGateResponse response = await _reportService.EditGate(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Status);
        }*/

        /*[HttpPatch("DisableGate/{gateId}")]
        public async Task<IActionResult> DisableGate([FromBody] JsonArray payload, [FromRoute] string gateId) //JSON ARRAY???
        {

            DisableGateRequest request = CreateServiceRequest<DisableGateRequest>(payload, gateId);
            DisableGateResponse response = await _reportService.DisableGate(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Status);
        }*/

        /*[HttpPatch("EnableGate/{gateId}")]
        public async Task<IActionResult> EnableGate([FromBody] JsonArray payload, [FromRoute] string gateId) //JSON ARRAY???
        {

            EnableGateRequest request = CreateServiceRequest<EnableGateRequest>(payload, gateId);
            EnableGateResponse response = await _reportService.EnableGate(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Status);
        }*/

        //STATISTICS

        //PAYMENT

    }
}
