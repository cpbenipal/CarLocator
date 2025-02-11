using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Enums;
using CLIMFinders.Application.Interfaces;
using CLIMFinders.Application.Services;
using CLIMFinders.Web.Pages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CLIMFinders.Web.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IJwtTokenService jwtTokenService, IAuthService authService) : ControllerBase
    {
        private readonly IAuthService authService = authService;
        private readonly IJwtTokenService _jwtTokenService = jwtTokenService;

        [HttpGet("testest")]
        public IActionResult LLL()
        {
            return Ok(new { token = "Done" });
        }
        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDto model)
        {
            var loginObj = new LoginDto();  
            loginObj.Email = model.Email;
            loginObj.Password = model.Password;


            var result = authService.UserLogin(loginObj);
            string? token = null;
            if (result != null)
            {
                token = _jwtTokenService.GenerateToken(result);
                result.Token = token;
                Response.Cookies.Append("AuthToken", token, new CookieOptions { HttpOnly = true, Secure = true });
            }

            return Ok(new { result });
        }
    }
}
