using Employee.Application.Commands.Users;
using Employee.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            var userId = await _mediator.Send(new RegisterUserCommand { UserDto = dto });
            return CreatedAtAction(nameof(Register), new { id = userId });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            var token = await _mediator.Send(new LoginUserCommand { UserDto = dto });

            Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true,                     // 🟢 Solo accesible desde HTTP requests
                Secure = true,                       // 🟢 Solo se envía por HTTPS
                SameSite = SameSiteMode.Strict,        // 🟢 Permitir cross-site (si están en dominios distintos)
                Expires = DateTime.UtcNow.AddHours(1)
            });


            return Ok(new { message = "Login exitoso" });
        }
        [Authorize]
        [HttpGet("protected")]
        public IActionResult ProtectedEndpoint()
        {
            return Ok(new { message = "Tienes acceso porque tu token es válido." });
        }
        [Authorize]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new { message = "Cookie eliminada" });
        }
    }
}
