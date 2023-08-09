using AppHistoryServer.Dtos.AuthDtos;
using AppHistoryServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppHistoryServer.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                return Created("/register", await _authService.Register(registerDto));
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Неизвестная ошибка, повторите попытку.");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                return Ok(await _authService.Login(loginDto));
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Неизвестная ошибка, повторите попытку.");
            }
        }
        [HttpGet("me")]
        public async Task<IActionResult> GetMe()
        {
            try
            {
                return Ok(await _authService.GetMe());
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new { message = "Не валидный токен."});
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { message = "Неизвестная ошибка, повторите попытку." });
            }
            catch (ArgumentException)
            {
                return Unauthorized(new { message = "Не валидный токен." });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ToString());
                return StatusCode(500, new { message = "Неизвестная ошибка, повторите попытку." });
            }
        }

    }
}
