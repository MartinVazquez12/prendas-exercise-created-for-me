using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prendasWebApi.Dtos;
using prendasWebApi.Models;
using prendasWebApi.Services;
using prendasWebApi.Services.Interfaz;

namespace prendasWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecuperatorioController : ControllerBase
    {
        private readonly IRecuperatorioService _recuperatorioService;

        public RecuperatorioController(IRecuperatorioService recuperatorioService)
        {
            _recuperatorioService = recuperatorioService;
        }

        [HttpGet("/GetMarcas")]
        public async Task<ActionResult<List<Marca>>> GetMarcas()
        {
            return Ok(await _recuperatorioService.GetMarcasAsync());
        }

        [HttpGet("/GetPrendas")]
        public async Task<ActionResult> GetPrendas()
        {
            return Ok(await _recuperatorioService.GetPrendasAsync());
        }

        [HttpGet("/GetPrendaById/{id}")]
        public async Task<ActionResult> GetPrendaById(Guid id)
        {
            var result = await _recuperatorioService.GetPrendaById(id);
            if (!result.Success)
            {
                return StatusCode((int)result.StatusCode, result.Data);
            }
            return Ok(result.Data);
        }

        [HttpPost("/PostPrenda")]
        public async Task<IActionResult> PostPrenda([FromBody] PrendaPostDto prenda)
        {
            try
            {
                var response = await _recuperatorioService.PostPrenda(prenda);

                if (response.Success)
                {
                    return Ok(response.Data);
                }
                else
                {
                    return BadRequest(response.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
