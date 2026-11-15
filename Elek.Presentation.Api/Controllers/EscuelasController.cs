using Elek.Application.Services.Escuelas;
using Elek.Application.Services.Escuelas.DTO;
using Elek.Presentation.Api.Contracts.Escuelas;
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
        [HttpGet("{uuid}")]
        public async Task<IActionResult> Get(Guid uuid)
        {
            try
            {
                return Ok(await _escuelaService.ObtenEscuela(uuid));
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                return StatusCode(500, "An error occurred while retrieving schools.");
            }
        }

        // POST api/<EscuelasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EscuelaRequest escuelaRequest)
        {
            try
            {
                EscuelaDTO escuelaDTO = escuelaRequest;
                return Created("", await _escuelaService.CrearEscuela(escuelaDTO));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new
                {
                    ex.Message
                });
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                return StatusCode(500, "An error occurred while retrieving schools.");
            }
        }

        // PUT api/<EscuelasController>/5
        [HttpPut("{uuid}")]
        public async Task<IActionResult> Put(Guid uuid, [FromBody] EscuelaRequest escuelaRequest)
        {
            try
            {
                if (uuid == Guid.Empty)
                {
                    return BadRequest("Invalid UUID provided.");
                }
                if (escuelaRequest == null)
                {
                    return BadRequest("Escuela data is required.");
                }
                EscuelaDTO escuelaDTO = escuelaRequest;
                escuelaDTO.UUID = uuid; // Ensure the UUID is set from the route parameter
                return Ok(await _escuelaService.ActualizaEscuela(escuelaDTO));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new
                {
                    ex.Message
                });
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                return StatusCode(500, "An error occurred while updating the school.");
            }
        }

        // PATCH api/<EscuelasController>/5
        [HttpPatch("name/{uuid}")]
        public async Task<IActionResult> PatchName(Guid uuid, [FromBody] string nombre)
        {
            try
            {
                if (uuid == Guid.Empty)
                {
                    return BadRequest("Invalid UUID provided.");
                }
                if (nombre == null)
                {
                    return BadRequest("nombre is required.");
                }
                EscuelaDTO escuelaDTO = new EscuelaDTO
                {
                    Nombre = nombre,
                    UUID = uuid
                };
                return Ok(await _escuelaService.ActualizaNombreEscuela(escuelaDTO));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new
                {
                    ex.Message
                });
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                return StatusCode(500, "An error occurred while updating the school.");
            }
        }
        // PATCH api/<EscuelasController>/5
        [HttpPatch("description/{uuid}")]
        public async Task<IActionResult> PatchDescription(Guid uuid, [FromBody] string description)
        {
            try
            {
                if (uuid == Guid.Empty)
                {
                    return BadRequest("Invalid UUID provided.");
                }
                if (description == null)
                {
                    return BadRequest("description is required.");
                }
                EscuelaDTO escuelaDTO = new EscuelaDTO
                {
                    Descripcion = description,
                    UUID = uuid
                };
                return Ok(await _escuelaService.ActualizaDescripcionEscuela(escuelaDTO));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new
                {
                    ex.Message
                });
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                return StatusCode(500, "An error occurred while updating the school.");
            }
        }

        // DELETE api/<EscuelasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
