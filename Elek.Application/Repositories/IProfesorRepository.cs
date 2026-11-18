using Elek.Application.Services.Escuelas.DTO;
using Elek.Application.Services.Profesores.DTO;
using Elek.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elek.Application.Repositories
{
    public interface IProfesorRepository
    {
        public Task<ProfesorDTO> Create(Profesor user);
        public Task<ProfesorDTO> Read(Guid UUID);
        public Task<List<ProfesorDTO>> ReadAll();
        public Task<ProfesorDTO> Update(Profesor user);
        public Task<ProfesorDTO> UpdateName(Profesor user);
        public Task<ProfesorDTO> UpdateApellido(Profesor user);
        public Task<ProfesorDTO> Delete(Guid UUID);
    }
}
