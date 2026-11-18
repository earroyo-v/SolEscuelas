using Elek.Application.Services.Escuelas;
using Elek.Application.Services.Escuelas.DTO;
using Elek.Application.Services.Profesores;
using Elek.Application.Services.Profesores.DTO;
using Elek.Presentation.Api.Contracts.Escuelas;
using Elek.Presentation.Api.Contracts.Profesores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Elek.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly IProfesorService _profesorService;
        public ProfesoresController(IProfesorService profesorService)
        {
            _profesorService = profesorService;
        }
        // GET: api/<ProfesoresController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _profesorService.ObtenProfesores());
            }
            catch (Exception)
            {
                // Log the exception (you can use a logging framework here)
                return StatusCode(500, "An error occurred while retrieving professors.");
            }
        }

        // GET api/<ProfesoresController>/5
        [HttpGet("{uuid}")]
        public async Task<IActionResult> Get(Guid uuid)
        {
            try
            {
                return Ok(await _profesorService.ObtenProfesor(uuid));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception)
            {
                // Log the exception (you can use a logging framework here)
                return StatusCode(500, "An error occurred while retrieving schools.");
            }
        }

        // POST api/<ProfesoresController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProfesorRequest profesorRequest)
        {
            try
            {
                ProfesorDTO profesorDTO = profesorRequest;
                return Created("", await _profesorService.CrearProfesor(profesorDTO));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }            
            catch (SqlException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new
                {
                    ex.Message
                });
            }
            catch (Exception)
            {
                // Log the exception (you can use a logging framework here)
                return StatusCode(500, "An error occurred while retrieving professors.");
            }
        }

        // PUT api/<ProfesoresController>/5
        [HttpPut("{uuid}")]
        public async Task<IActionResult> Put(Guid uuid, [FromBody] ProfesorRequest profesorRequest)
        {
            try
            {
                if (uuid == Guid.Empty)
                {
                    return BadRequest("Invalid UUID provided.");
                }
                if (profesorRequest == null)
                {
                    return BadRequest("Profesor data is required.");
                }
                ProfesorDTO profesorDTO = profesorRequest;
                profesorDTO.Uuid = uuid; // Ensure the UUID is set from the route parameter
                return Ok(await _profesorService.ActualizaProfesor(profesorDTO));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (SqlException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new
                {
                    ex.Message
                });
            }
            catch (Exception)
            {
                // Log the exception (you can use a logging framework here)
                return StatusCode(500, "An error occurred while updating the school.");
            }
        }
        /*
        // PATCH api/<ProfesoresController>/5
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
                    Uuid = uuid
                };
                return Ok(await _profesorService.ActualizaNombreProfesor(escuelaDTO));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (SqlException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new
                {
                    ex.Message
                });
            }
            catch (Exception)
            {
                // Log the exception (you can use a logging framework here)
                return StatusCode(500, "An error occurred while updating the school.");
            }
        }
        // PATCH api/<ProfesoresController>/5
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
                    Uuid = uuid
                };
                return Ok(await _profesorService.ActualizaDescripcionProfesor(escuelaDTO));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (SqlException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new
                {
                    ex.Message
                });
            }
            catch (Exception)
            {
                // Log the exception (you can use a logging framework here)
                return StatusCode(500, "An error occurred while updating the school.");
            }
        }*/

        // DELETE api/<ProfesoresController>/5
        [HttpDelete("{uuid}")]
        public async Task<IActionResult> Delete(Guid uuid)
        {
            try
            {
                if (uuid == Guid.Empty)
                {
                    return BadRequest("Invalid UUID provided.");
                }
                return Ok(await _profesorService.EliminaProfesor(uuid));
            }
            catch (SqlException ex) when (ex.Number == 50003)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (SqlException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new
                {
                    ex.Message
                });
            }
            catch (Exception)
            {
                // Log the exception (you can use a logging framework here)
                return StatusCode(500, "An error occurred while deleting the profesor.");
            }
        }
    }
}
