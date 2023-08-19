using AppHistoryServer.Models;
using AppHistoryServer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppHistoryServer.Controllers
{
    [Route("api/topics")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        // TODO: delete
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _topicService.GetByIdAsync(id);
                if (result == null)
                    return Ok(new { });
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Неизвестная ошибка, повторите попытку.");
            }
        }


        [HttpGet("get-by-module/{moduleId}/{topicId}")]
        public async Task<IActionResult> Get(int moduleId, int topicId)
        {
            try
            {
                var result = await _topicService.GetByModuleIdAndTopicIdAsync(moduleId, topicId);
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
        
        [HttpGet("get-by-module/{moduleId}")]
        public async Task<IActionResult> GetTopics(int moduleId)
        {
            try
            {
                var result = await _topicService.GetTopicsByModuleIdAsync(moduleId);
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
        
   

        // TODO: delete
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_topicService.GetAll());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Неизвестная ошибка, повторите попытку.");
            }
        }
    }
}
