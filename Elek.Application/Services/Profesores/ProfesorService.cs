using Elek.Application.Services.Profesores.DTO;
using Elek.Application.Services.Profesores.Mappers;
using Elek.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elek.Application.Services.Profesores
{
    public class ProfesorService : IProfesorService
    {
        private readonly Repositories.IProfesorRepository _profesorRepository;
        public ProfesorService(Repositories.IProfesorRepository profesorRepository)
        {
            _profesorRepository = profesorRepository;
        }
        public async Task<ProfesorDTO> ActualizaProfesor(ProfesorDTO profesorDTO)
        {
            var existingProfesor = await _profesorRepository.Read(profesorDTO.Uuid);
            if (existingProfesor == null)
                throw new KeyNotFoundException("El profesor no existe.");
            var profesor_domain = new Profesor(existingProfesor.Id, existingProfesor.Nombre, existingProfesor.Apellido, existingProfesor.IdEscuela, existingProfesor.Uuid);
            profesor_domain.Update(profesorDTO.Nombre, profesorDTO.Apellido, profesorDTO.IdEscuela);
            var profesor = await _profesorRepository.Update(profesor_domain);
            return profesor;
        }
        public async Task<ProfesorDTO> ActualizaNombreProfesor(ProfesorDTO profesorDTO)
        {
            throw  new NotImplementedException("El método ActualizaNombreProfesor aún no está implementado.");
            //var existingProfesor = await _profesorRepository.Read(profesorDTO.Uuid);
            //if (existingProfesor == null)
            //    throw new KeyNotFoundException("El profesor no existe.");
            //var profesor_domain = new Profesor(existingProfesor.Id, existingProfesor.Nombre, existingProfesor.Apellido, existingProfesor.IdEscuela, existingProfesor.Uuid);
            //profesor_domain.ActualizarNombre(profesorDTO.Nombre);
            //var profesor = await _profesorRepository.UpdateName(profesor_domain);
            //return profesor;
        }
        public async Task<ProfesorDTO> ActualizaApellidoProfesor(ProfesorDTO profesorDTO)
        {
            throw new NotImplementedException("El método ActualizaNombreProfesor aún no está implementado.");

            //var existingProfesor = await _profesorRepository.Read(profesorDTO.UUID);
            //if (existingProfesor == null)
            //    throw new KeyNotFoundException("El profesor no existe.");
            //var profesor_domain = new Profesor(existingProfesor.Id, existingProfesor.Nombre, existingProfesor.Apellido, existingProfesor.UUID);
            //profesor_domain.ActualizarApellido(profesorDTO.Apellido);
            //var profesor = await _profesorRepository.UpdateLastName(profesor_domain);
            //return profesor;
        }

        public async Task<ProfesorDTO> CrearProfesor(ProfesorDTO profesorDTO)
        {
            var profesor_domain = Profesor.Create(profesorDTO.Nombre, profesorDTO.Apellido, profesorDTO.IdEscuela);
            var profesor = await _profesorRepository.Create(profesor_domain);
            return profesor;
        }

        public async Task<ProfesorDTO> EliminaProfesor(Guid UUID)
        {
            var profesor = await _profesorRepository.Delete(UUID);
            return profesor;
        }

        public async Task<ProfesorDTO> ObtenProfesor(Guid UUID)
        {
            var profesor = await _profesorRepository.Read(UUID);
            if (profesor == null)
                throw new KeyNotFoundException("El profesor no existe.");
            return profesor;
        }

        public async Task<List<ProfesorDTO>> ObtenProfesores()
        {
            var profesores = await _profesorRepository.ReadAll();
            return profesores;
        }
    }
}
