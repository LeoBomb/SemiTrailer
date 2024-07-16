using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Security.Claims;
using UseCases.Dtos;
using UseCases.Interface;
using UseCases.Models;

namespace SemiTrailer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task Login(string account, string password)
        {
            var userLoginDto = await _authService.LoginVerify(account, password);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, userLoginDto.Id.ToString()),
            };
            var authenticationProperties = new AuthenticationProperties()
            {
                IsPersistent = false,
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddDays(1),
            };
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
            await HttpContext.SignInAsync(claimsPrincipal, authenticationProperties);
        }

        [HttpPost("Logout")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync();
        }
        [Authorize()]
        [HttpPost()]
        public async Task Create(CreateUserReq createUserReq)
        {
            var userId = await _authService.CreateUser(createUserReq);
            await _authService.CreateTenantDb(userId);
        }
        [Authorize()]
        [HttpGet("all")]
        public async Task<List<UserDto>> GetList()
        {
            var data = await _authService.GetList();
            return data;
        }
    }
}
