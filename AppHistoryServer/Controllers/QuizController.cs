using AppHistoryServer.Dtos.QuestionDtos;
using AppHistoryServer.Dtos.QuizDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Services.Impl;
using AppHistoryServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace AppHistoryServer.Controllers
{
    [Route("api/quizzes")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_quizService.GetAll());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Неизвестная ошибка, повторите попытку позже...");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _quizService.GetByIdAsync(id);
                if (result == null)
                    return Ok(new { });
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Неизвестная ошибка, повторите попытку позже...");
            }
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            try
            {
                var result = await _quizService.GetDetailByIdAsync(id);
                if (result == null)
                    return Ok(new { });
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Неизвестная ошибка, повторите попытку позже...");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QuizPostDto quizPostDto)
        {
            try
            {
                return Ok(await _quizService.CreateAsync(quizPostDto));
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (SecurityTokenExpiredException ex)
            {
                return Unauthorized(new { message = "Срок действия токена истек" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Неизвестная ошибка, повторите попытку позже...");

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] QuizPostDto quizPostDto)
        {
            try
            {
                var updated = await _quizService.UpdateAsync(id, quizPostDto);
                return Ok(updated);
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Неизвестная ошибка, повторите попытку позже...");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _quizService.DeleteAsync(id);
                return Ok();
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("Неизвестная ошибка, повторите попытку позже...");
            }
        }

        [HttpPatch("set-image/{id}")]
        public async Task<IActionResult> ChangeImage(int id, [FromForm] IFormFile file)
        {
            try
            {
                await _quizService.ChangeImage(id, file);
                return Ok();
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Неизвестная ошибка, повторите попытку позже...");
            }
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetByFilter(string type, string category)
        {
            try
            {
                return Ok(await _quizService.GetByFilterAsync(type, category));
            }
            catch(SecurityTokenExpiredException)
            {
                return Unauthorized(new {message="Срок действия токена истек"});
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Неизвестная ошибка, повторите попытку позже...");
            }
        }

        [HttpPost("pass-quiz")]
        public async Task<IActionResult> PassQuiz([FromBody] QuizPassedDto quizPassedDto)
        {
            try
            {
                return Ok(await _quizService.PassQuizAsync(quizPassedDto));
            }
            catch (SecurityTokenExpiredException)
            {
                return Unauthorized(new { message = "Срок действия токена истек" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Неизвестная ошибка, повторите попытку позже...");
            }
        }
    }
}
