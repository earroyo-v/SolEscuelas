using Elek.Application.Services.Escuelas.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elek.Application.Services.Escuelas
{
    public interface IEscuelaService
    {
        public Task<EscuelaDTO> CrearEscuela(EscuelaDTO escuelaDTO);
        public Task<EscuelaDTO> ObtenEscuela(Guid UUID);
        public Task<List<EscuelaDTO>> ObtenEscuelas();
        public Task<EscuelaDTO> ActualizaEscuela(EscuelaDTO escuelaDTO);
        public Task<EscuelaDTO> ActualizaNombreEscuela(EscuelaDTO escuelaDTO);
        public Task<EscuelaDTO> ActualizaDescripcionEscuela(EscuelaDTO escuelaDTO);
        public Task EliminaEscuela(Guid UUID);
    }
}
