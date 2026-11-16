using Elek.Application.Services.Escuelas.DTO;
using Elek.Application.Services.Escuelas.Mappers;
using Elek.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elek.Application.Services.Escuelas
{
    public class EscuelaService : IEscuelaService
    {
        private readonly Repositories.IEscuelaRepository _escuelaRepository;
        public EscuelaService(Repositories.IEscuelaRepository escuelaRepository)
        {
            _escuelaRepository = escuelaRepository;
        }
        public async Task<EscuelaDTO> ActualizaEscuela(EscuelaDTO escuelaDTO)
        {
            var existingEscuela = await _escuelaRepository.Read(escuelaDTO.UUID);
            if (existingEscuela == null)
                throw new KeyNotFoundException("La escuela no existe.");
            var escuela_domain = new Escuela(existingEscuela.Id, existingEscuela.Nombre, existingEscuela.Descripcion, existingEscuela.UUID);
            escuela_domain.Actualizar(escuelaDTO.Nombre, escuelaDTO.Descripcion);
            var escuela = await _escuelaRepository.Update(escuela_domain);
            return escuela;
        }
        public async Task<EscuelaDTO> ActualizaNombreEscuela(EscuelaDTO escuelaDTO)
        {
            var existingEscuela = await _escuelaRepository.Read(escuelaDTO.UUID);
            if (existingEscuela == null)
                throw new KeyNotFoundException("La escuela no existe.");
            var escuela_domain = new Escuela(existingEscuela.Id, existingEscuela.Nombre, existingEscuela.Descripcion, existingEscuela.UUID);
            escuela_domain.ActualizarNombre(escuelaDTO.Nombre);
            var escuela = await _escuelaRepository.UpdateName(escuela_domain);
            return escuela;
        }
        public async Task<EscuelaDTO> ActualizaDescripcionEscuela(EscuelaDTO escuelaDTO)
        {
            var existingEscuela = await _escuelaRepository.Read(escuelaDTO.UUID);
            if (existingEscuela == null)
                throw new KeyNotFoundException("La escuela no existe.");
            var escuela_domain = new Escuela(existingEscuela.Id, existingEscuela.Nombre, existingEscuela.Descripcion, existingEscuela.UUID);
            escuela_domain.ActualizarDescripcion(escuelaDTO.Descripcion);
            var escuela = await _escuelaRepository.UpdateDescription(escuela_domain);
            return escuela;
        }

        public async Task<EscuelaDTO> CrearEscuela(EscuelaDTO escuelaDTO)
        {
            var escuela_domain = Escuela.Create(escuelaDTO.Nombre, escuelaDTO.Descripcion);
            var escuela = await _escuelaRepository.Create(escuela_domain);
            return escuela;
        }

        public async Task<EscuelaDTO> EliminaEscuela(Guid UUID)
        {
            var escuela = await _escuelaRepository.Delete(UUID);
            return escuela;
        }

        public async Task<EscuelaDTO> ObtenEscuela(Guid UUID)
        {
            var escuela = await _escuelaRepository.Read(UUID);
            if (escuela == null)
                throw new KeyNotFoundException("La escuela no existe.");
            return escuela;
        }

        public async Task<List<EscuelaDTO>> ObtenEscuelas()
        {
            var escuelas = await _escuelaRepository.ReadAll();
            return escuelas;
        }
    }
}
