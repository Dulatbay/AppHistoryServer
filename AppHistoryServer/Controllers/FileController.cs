using AppHistoryServer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppHistoryServer.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FileController : ControllerBase
    {
        protected readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }



        [HttpPost]
        public async Task<IActionResult> PostFile(IFormFile file)
        {
            try
            {
                return Ok(new { message = await _fileService.CreateFileAsync(file) });   
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
    }
}
