using Elek.Application.Services.Profesores.DTO;
using Elek.Domain.Domain;
using Elek.Infrastructure.Persistence.StoredProcedures.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elek.Infrastructure.Mappers
{
    public static class ProfesorMapper
    {
        public static ProfesorDTO ToDTO(this Profesor profesor)
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
        public static Profesor ToDomain(this ProfesorDTO profesorDTO)
        {
            return new Profesor(profesorDTO.Id, profesorDTO.Nombre, profesorDTO.Apellido, profesorDTO.IdEscuela, profesorDTO.Uuid);
        }
        public static ProfesorDTO ToDTO(this ProfesorSP profesorSP)
        {
            return new ProfesorDTO
            {
                Id = profesorSP.Id,
                Nombre = profesorSP.Nombre,
                Apellido = profesorSP.Apellido,
                IdEscuela = profesorSP.IdEscuela,
                Uuid = profesorSP.Uuid
            };
        }
    }
}
