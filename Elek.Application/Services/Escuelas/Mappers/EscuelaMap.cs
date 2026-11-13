using Elek.Application.Services.Escuelas.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elek.Application.Services.Escuelas.Mappers
{
    public static class EscuelaMap
    {
        public static EscuelaDTO ToDTO(this Domain.Domain.Escuela escuela)
        {
            return new EscuelaDTO
            {
                Id = escuela.Id,
                Nombre = escuela.Nombre,
                Descripcion = escuela.Descripcion,
                UUID = escuela.UUID
            };
        }
        public static Domain.Domain.Escuela ToDomain(this EscuelaDTO escuelaDTO)
        {
            return new Domain.Domain.Escuela(escuelaDTO.Id, escuelaDTO.Nombre, escuelaDTO.Descripcion, escuelaDTO.UUID);
        }
    }
}
