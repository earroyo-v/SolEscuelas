using Elek.Application.Services.Escuelas.DTO;
using Elek.Infrastructure.Persistence.StoredProcedures.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elek.Infrastructure.Mappers
{
    public static class EscuelaMapper
    {
        public static Application.Services.Escuelas.DTO.EscuelaDTO ToDTO(this Domain.Domain.Escuela escuela)
        {
            return new Application.Services.Escuelas.DTO.EscuelaDTO
            {
                Id = escuela.Id,
                Nombre = escuela.Nombre,
                Descripcion = escuela.Descripcion,
                UUID = escuela.UUID
            };
        }
        public static Domain.Domain.Escuela ToDomain(this Application.Services.Escuelas.DTO.EscuelaDTO escuelaDTO)
        {
            return new Domain.Domain.Escuela(escuelaDTO.Id, escuelaDTO.Nombre, escuelaDTO.Descripcion, escuelaDTO.UUID);
        }
        public static EscuelaDTO ToDTO(this EscuelaSP escuelaSP)
        {
            return new EscuelaDTO
            {
                Id = escuelaSP.Id,
                Nombre = escuelaSP.Nombre,
                Descripcion = escuelaSP.Descripcion,
                UUID = escuelaSP.Uuid
            };
        }
    }
}
