using Elek.Application.Services.Escuelas.DTO;
using Elek.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elek.Application.Repositories
{
    public interface IEscuelaRepository
    {
        public Task<EscuelaDTO> Create(Escuela user);
        public Task<EscuelaDTO> Read(Guid UUID);
        public Task<List<EscuelaDTO>> ReadAll();
        public Task Update(Escuela user);
        public Task Delete(Guid UUID);
    }
}
