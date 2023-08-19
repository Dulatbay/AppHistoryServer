using AppHistoryServer.Services.Impl;
using AppHistoryServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppHistoryServer.Controllers
{
    [Route("api/modules")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;

        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        [HttpGet("get-titles")]
        public IActionResult GetAllModuleTopicsTitle()
        {
            try
            {
                var result = _moduleService.GetAllModuleTopicsTitle();
                if (result == null)
                    return Ok(new { });
                return Ok(result);
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

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_moduleService.GetAll());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500,"Неизвестная ошибка, повторите попытку позже...");
            }
        }

        // GET api/<ModuleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _moduleService.GetByIdAsync(id);
                if(result == null)
                    return Ok(new { });
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Неизвестная ошибка, повторите попытку позже...");
            }
        }
    }
}
