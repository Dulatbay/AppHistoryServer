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
