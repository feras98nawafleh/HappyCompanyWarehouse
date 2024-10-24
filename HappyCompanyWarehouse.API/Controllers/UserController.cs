using HappyCompanyWarehouse.Domain.DTOs;
using HappyCompanyWarehouse.Domain.Models;
using HappyCompanyWarehouse.Domain.Models.DTO;
using HappyCompanyWarehouse.Domain.Models.Response;
using HappyCompanyWarehouse.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HappyCompanyWarehouse.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        private IAuthService _authService;
        public UserController(UserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<ResponseEnvelop<string>>> Login(LoginDTO login)
        {
            var resultData = await _authService.Login(login);
            var response = new ResponseEnvelop<string>()
                .SetSuccess(true)
                .SetResult(resultData)
                .SetResultMessage("Success")
                .SetStatusCode(resultData.IsNullOrEmpty() ? System.Net.HttpStatusCode.NoContent : System.Net.HttpStatusCode.OK)
                .Build();

            return response;
        }
        [HttpGet("Refresh")]
        public async Task<ActionResult<ResponseEnvelop<string>>> Refresh()
        {
            var resultData = await _authService.Refresh();
            var response = new ResponseEnvelop<string>()
                .SetSuccess(true)
                .SetResult(resultData)
                .SetResultMessage("Success")
                .SetStatusCode(resultData.IsNullOrEmpty() ? System.Net.HttpStatusCode.NoContent : System.Net.HttpStatusCode.OK)
                .Build();

            return response;
        }

        [HttpGet("GetUser")]
        public async Task<ActionResult<ResponseEnvelop<UserDTO>>> GetUser(int userId)
        {
            var data = await _userService.GetUser(userId);
            var response = new ResponseEnvelop<UserDTO>()
                .SetSuccess(true)
                .SetResult(data)
                .SetResultMessage("Success")
                .SetStatusCode(System.Net.HttpStatusCode.OK)
                .Build();

            return Ok(response);
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<ResponseEnvelop<List<UserDTO>>>> GetUsers()
        {
            var data = await _userService.GetUsers();
            var response = new ResponseEnvelop<List<UserDTO>>()
                .SetSuccess(true)
                .SetResult(data)
                .SetResultMessage("Success")
                .SetStatusCode(System.Net.HttpStatusCode.OK)
                .Build();

            return Ok(response);
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<ResponseEnvelop<UserDTO>>> AddUser(UserDTO user)
        {
            var data = await _userService.AddUser(user);
            var response = new ResponseEnvelop<UserDTO>()
                .SetSuccess(true)
                .SetResult(data)
                .SetResultMessage("Success")
                .SetStatusCode(data is null ? System.Net.HttpStatusCode.BadRequest : System.Net.HttpStatusCode.OK)
                .Build();

            return Ok(response);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<ResponseEnvelop<UserDTO>>> UpdateUser(UserDTO user)
        {
            var data = await _userService.UpdateUser(user);
            var response = new ResponseEnvelop<UserDTO>()
                .SetSuccess(true)
                .SetResult(data)
                .SetResultMessage("Success")
                .SetStatusCode(System.Net.HttpStatusCode.OK)
                .Build();

            return Ok(response);
        }
    }
}
