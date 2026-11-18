using Elek.Application.Services.Profesores.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elek.Application.Services.Profesores.Mappers
{
    public static class ProfesorMap
    {
        public static ProfesorDTO ToDTO(this Domain.Domain.Profesor profesor)
        {
            return new ProfesorDTO
            {
                Id = profesor.Id,
                Nombre = profesor.Nombre,
                Apellido = profesor.Apellido,
                IdEscuela = profesor.IdEscuela,
                Uuid = profesor.Uuid
            };
        }
        public static Domain.Domain.Profesor ToDomain(this ProfesorDTO profesorDTO)
        {
            return new Domain.Domain.Profesor(profesorDTO.Id, profesorDTO.Nombre, profesorDTO.Apellido, profesorDTO.IdEscuela, profesorDTO.Uuid);
        }
    }
}
