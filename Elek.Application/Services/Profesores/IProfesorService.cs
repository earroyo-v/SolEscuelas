using Elek.Application.Services.Profesores.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elek.Application.Services.Profesores
{
    public interface IProfesorService
    {
        public Task<ProfesorDTO> CrearProfesor(ProfesorDTO profesorDTO);
        public Task<ProfesorDTO> ObtenProfesor(Guid UUID);
        public Task<List<ProfesorDTO>> ObtenProfesores();
        public Task<ProfesorDTO> ActualizaProfesor(ProfesorDTO profesorDTO);
        public Task<ProfesorDTO> ActualizaNombreProfesor(ProfesorDTO profesorDTO);
        public Task<ProfesorDTO> ActualizaApellidoProfesor(ProfesorDTO profesorDTO);
        public Task<ProfesorDTO> EliminaProfesor(Guid UUID);
    }
}
