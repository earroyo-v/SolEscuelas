using Elek.Application.Services.Escuelas.DTO;

namespace Elek.Presentation.Api.Contracts.Escuelas
{
    public class EscuelaRequest
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public static implicit operator EscuelaDTO (EscuelaRequest escuela)
        {
            return new EscuelaDTO
            {
                Nombre = escuela.Nombre,
                Descripcion = escuela.Descripcion
            };
        }
    }
}
