using System;
using System.Threading.Tasks;
using Curs_1.Data;
using Curs_1.Models;
using Curs_1.ViewModels.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Curs_1.Services;

namespace Curs_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthManagementService _authenticationService;

        public AuthenticationController(IAuthManagementService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("register")] // /api/authentication/register
        public async Task<ActionResult> RegisterUser(RegisterRequest registerRequest)
        {
            var registerServiceResult = await _authenticationService.RegisterUser(registerRequest);
            if (registerServiceResult.ResponseError != null)
            {
                return BadRequest(registerServiceResult.ResponseError);
            }

            return Ok(registerServiceResult.ResponseOk);
        }

        [HttpPost]
        [Route("confirm")]
        public async Task<ActionResult> ConfirmUser(ConfirmUserRequest confirmUserRequest)
        {
            var serviceResult = await _authenticationService.ConfirmUserRequest(confirmUserRequest);
            if (serviceResult)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginRequest loginRequest) 
        {
            var serviceResult = await _authenticationService.LoginUser(loginRequest);
            if (serviceResult.ResponseOk != null)
            {
                return Ok(serviceResult.ResponseOk);
            }

            return Unauthorized();
        }
    }
}
