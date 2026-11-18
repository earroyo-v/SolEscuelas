using Elek.Application.Services.Escuelas.DTO;
using Elek.Application.Services.Profesores.DTO;
using Elek.Presentation.Api.Contracts.Escuelas;

namespace Elek.Presentation.Api.Contracts.Profesores
{
    public class ProfesorRequest
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public Guid UuidEscuela { get; set; }
        public static implicit operator ProfesorDTO(ProfesorRequest profesor)
        {
            return new ProfesorDTO
            {
                Nombre = profesor.Nombre,
                Apellido = profesor.Apellido,
                escuela = new EscuelaDTO { UUID = profesor.UuidEscuela }
            };
        }
    }
}
