using Elek.Application.Services.Escuelas;
using Elek.Application.Services.Escuelas.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elek.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscuelasController : ControllerBase
    {
        private readonly IEscuelaService _escuelaService;
        public EscuelasController(IEscuelaService escuelaService)
        {
            _escuelaService = escuelaService;
        }
        // GET: api/<EscuelasController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _escuelaService.ObtenEscuelas());
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                return StatusCode(500, "An error occurred while retrieving schools.");
            }
        }

        // GET api/<EscuelasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EscuelasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string nombre, string descripcion)
        {
            try
            {
                var escuelaDTO = new EscuelaDTO { Nombre = nombre, Descripcion = descripcion };
                return Created("", await _escuelaService.CrearEscuela(escuelaDTO));
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                return StatusCode(500, "An error occurred while retrieving schools.");
            }
        }

        // PUT api/<EscuelasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EscuelasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
