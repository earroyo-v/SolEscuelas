using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elek.Application.Services.Escuelas
{
    public interface IEscuelaService
    {
        public Task CrearEscuela(DTO.EscuelaDTO escuelaDTO);
        public Task<DTO.EscuelaDTO> ObtenEscuela(Guid UUID);
        public Task<List<DTO.EscuelaDTO>> ObtenEscuelas();
        public Task ActualizaEscuela(DTO.EscuelaDTO escuelaDTO);
        public Task EliminaEscuela(Guid UUID);
    }
}
