using AutoMapper;
using Breadr.Core.Web;
using Breadr.Service.ProfileManager;
using Breadr.Service.ProfileManager.Models;
using Breadr.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Breadr.Controllers
{
    [ApiController]
    public class ProfileManagerController : ApiControllerBase
    {

        private readonly IProfileManagerService _profileManagerService;
        private readonly IMapper _mapper;

        public ProfileManagerController(IProfileManagerService profileManagerService, IMapper mapper)
        {
            _profileManagerService = profileManagerService;
            _mapper = mapper;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]UserLoginViewModel user)
        {


            UserLoginRequest request = _mapper.Map(user, CreateServiceRequest<UserLoginRequest>());
            UserLoginResponse response = await _profileManagerService.UserLogin(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.User);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationViewModel user)
        {


            UserRegisterRequest request = _mapper.Map(user, CreateServiceRequest<UserRegisterRequest>());
            UserRegisterResponse response = await _profileManagerService.UserRegister(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.User);
        }
    }
}
